using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Metaplay.Client.Messages;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Player;
using Metaplay.Metaplay.Core.Serialization;
using Metaplay.Metaplay.Core.Session;

namespace Metaplay.Metaplay.Core.Network
{
    public class ServerConnection
    {
        private readonly Config _config; // 0x18
        private readonly ServerEndpoint _endpoint; // 0x20

        private IMessageTransport _transport; // 0x28
        private object _transportLock; // 0x30
        private object _transportResetupLock; // 0x38
        private CancellationTokenSource _transportResetupCancellation; // 0x40
        private Task _transportResetupTask; // 0x48

        private object _incomingLock; // 0x50
        private List<MetaMessage> _incomingMessages; // 0x58
        private MessageTransport.Error _incomingError; // 0x60
        private ServerHandshakePhase _handshakePhase; // 0x68

        private object _enqueueCloseLock; // 0x70
        private bool _closeEnqueued; // 0x78
        private CreateTransportFn _createTransport; // 0x80
        private readonly BuildVersion _buildVersion; // 0x88
        private LoginCredentials _credentials; // 0xA0
        private SessionProtocol.SessionResourceProposal _resourceProposal; // 0xC8
        private ClientAppPauseStatus _clientAppPauseStatus; // 0xF0
        private int _currentSessionStartQueryId; // 0xF4
        private GetDebugDiagnosticsFn _getDebugDiagnostics; // 0xF8
        private EarlyMessageFilterSyncFn _earlyMessageFilterSyncFn; // 0x100
        private SessionState _currentSession; // 0x108
        private object _currentSessionSendQueueLock; // 0x110
        private TaskCompletionSource<MessageTransport.Error> _terminatingErrorTask; // 0x118
        private DateTime _connectionStartTime; // 0x120
        //private MetaTimer _pauseTerminationTimer; // 0x128
        private object _pauseTerminationTimerLock; // 0x130
        internal Stats _statistics; // 0x138
        private DateTime _watchdogDeadlineAt; // 0x148
        private TimeSpan _watchdogDeadlineLastDuration; // 0x150
        private object _watchdogLock; // 0x158
        private DateTime? _resetupDeadlineAt; // 0x160
        private TimeSpan _resetupDeadlineLastDuration; // 0x170
        private bool _enableWatchdog; // 0x178
        private Action _reportWatchdogViolation; // 0x180
        private DateTime _previousUpdateAt; // 0x188
        internal ServerGateway _currentGateway; // 0x190
        private int _numSuccessfulSessionResumes; // 0x198
        private LoginServerConnectionDebugDiagnostics _connDiagnostics; // 0x1A0
        private LoginTransportDebugDiagnostics _transportDiagnostics; // 0x1A8

        //private LogChannel Log { get; } // 0x10

        public bool IsLoggedIn => _handshakePhase == ServerHandshakePhase.InSession;

        public ServerConnection(/*LogChannel log, */Config config, ServerEndpoint endpoint, CreateTransportFn createTransport,
            BuildVersion buildVersion,
            LoginCredentials initialCredentials, SessionProtocol.SessionResourceProposal initialResourceProposal,
            ClientAppPauseStatus initialClientAppPauseStatus,
            GetDebugDiagnosticsFn getDebugDiagnostics,
            EarlyMessageFilterSyncFn earlyMessageFilterSync, bool enableWatchdog,
            Action reportWatchdogViolation, int numFailedConnectionAttempts)
        {
            _transportLock = new object();
            _transportResetupLock = new object();
            _transportResetupCancellation = new CancellationTokenSource();

            _incomingLock = new object();
            _incomingMessages = new List<MetaMessage>();

            _enqueueCloseLock = new object();

            _currentSessionSendQueueLock = new object();

            _pauseTerminationTimerLock = new object();

            _watchdogLock = new object();

            _connDiagnostics = new LoginServerConnectionDebugDiagnostics();
            _transportDiagnostics = new LoginTransportDebugDiagnostics();

            _config = config;
            _endpoint = endpoint;
            _createTransport = createTransport;
            _buildVersion = buildVersion;
            _credentials = initialCredentials;
            _getDebugDiagnostics = getDebugDiagnostics;
            _earlyMessageFilterSyncFn = earlyMessageFilterSync;
            _enableWatchdog = enableWatchdog;
            _resourceProposal = initialResourceProposal;
            _clientAppPauseStatus = initialClientAppPauseStatus;
            _reportWatchdogViolation = reportWatchdogViolation;
            _terminatingErrorTask = new TaskCompletionSource<MessageTransport.Error>();
            _previousUpdateAt = DateTime.UtcNow;
            _currentGateway = ServerGatewayScheduler.SelectGatewayForInitialConnection(_endpoint, numFailedConnectionAttempts);

            SetupTransport(null);
        }

        public void Dispose()
        {
            DisposeWithCause(null);
        }

        public bool EnqueueSendMessage(MetaMessage payloadMessage)
        {
            Interlocked.Increment(ref _connDiagnostics.SessionMessageEnqueuesAttempted);

            lock (_currentSessionSendQueueLock)
            {
                if (_currentSession == null)
                    return false;

                SessionUtil.HandleSendPayloadMessage(_currentSession.SessionParticipant, payloadMessage);
                if (_transport == null || _handshakePhase != ServerHandshakePhase.InSession)
                    Interlocked.Increment(ref _connDiagnostics.SessionMessagesDelayedSendEnqueues);
                else
                {
                    Interlocked.Increment(ref _connDiagnostics.SessionMessageImmediateSendEnqueues);
                    Interlocked.CompareExchange(ref _connDiagnostics.FirstSessionMessageSentAtMS, MetaTime.Now.MillisecondsSinceEpoch, 0);

                    _transport.EnqueueSendMessage(payloadMessage);
                }
            }

            Interlocked.Increment(ref _connDiagnostics.SessionMessagesEnqueues);
            return true;
        }

        public bool AbortSessionStart(SessionProtocol.SessionStartAbortReasonTrailer optionalReason)
        {
            return false;
        }

        public void RetrySessionStart(SessionProtocol.SessionResourceProposal resourceProposal, ClientAppPauseStatus clientAppPauseStatus)
        {
            _clientAppPauseStatus = clientAppPauseStatus;
            _resourceProposal = resourceProposal;

            if (_handshakePhase != ServerHandshakePhase.WaitingForSessionHandshakeCompletion)
                return;

            _currentSessionStartQueryId++;
            var req = new SessionProtocol.SessionStartRequest(_currentSessionStartQueryId, _config.DeviceModel, GetPlayerTimeZoneInfo(), _resourceProposal, false, _config.SessionStartGamePayload, CompressUtil.GetSupportedDecompressionAlgorithms(), _clientAppPauseStatus);

            _transport.EnqueueSendMessage(req);
        }

        public Task EnqueueCloseAsync()
        {
            return Task.CompletedTask;
        }

        public LoginSessionDebugDiagnostics TryGetLoginSessionDebugDiagnostics()
        {
            lock (_currentSessionSendQueueLock)
            {
                if (_currentSession == null)
                    return null;

                var flushActions = _currentSession.SessionParticipant.RememberedSent.OfType<PlayerFlushActions>();
                var selected = _currentSession.SessionParticipant.RememberedSent.Take(3).Select(x => 0).ToArray();

                return new LoginSessionDebugDiagnostics
                {
                    NumSent = _currentSession.SessionParticipant.NumSent,
                    NumRememberedSent = _currentSession.SessionParticipant.RememberedSent.Count,
                    FirstNRememberedSentMessageTypeCodes = selected,
                    TotalPendingFlushActionsOperationsBytes = flushActions.Sum(x => x.Operations.Bytes.Length),
                    TotalPendingFlushActionsChecksums = flushActions.Sum(x => x.Checksums.Length),
                    PreviousTransportErrorName = _currentSession.CurrentResumptionAttempt?.PreviousTransportError.GetType().Name
                };
            }
        }

        public LoginServerConnectionDebugDiagnostics GetLoginServerConnectionDebugDiagnostics()
        {
            return _connDiagnostics.Clone();
        }

        public LoginTransportDebugDiagnostics GetLoginTransportDebugDebugDiagnostics()
        {
            return _transportDiagnostics.Clone();
        }

        private void SetupTransport(TimeSpan? maxConnectTimeout)
        {
            lock (_transportLock)
            {
                _connectionStartTime = DateTime.UtcNow;

                var timeout = TimeSpan.FromMilliseconds(_config.ConnectTimeout.Milliseconds);
                timeout += TimeSpan.FromSeconds(5);

                SetWatchdog(timeout);

                _transport = _createTransport(_currentGateway, maxConnectTimeout);
                _transport.SetDebugDiagnosticsRef(_transportDiagnostics);

                _transport.OnConnect += HandleOnConnect;
                _transport.OnReceive += HandleOnReceive;
                _transport.OnInfo += HandleOnInfo;
                _transport.OnError += HandleOnError;

                EnqueueInfo(new TransportLifecycleInfo(true));

                _transport.Open();
            }

            Interlocked.Increment(ref _connDiagnostics.TransportsCreated);
        }

        private void SetWatchdog(TimeSpan watchdogValidFor)
        {
            lock (_watchdogLock)
            {
                _watchdogDeadlineAt = DateTime.UtcNow + watchdogValidFor;
                _watchdogDeadlineLastDuration = watchdogValidFor;
            }
        }

        private void EnqueueInfo(MessageTransport.Info info)
        {
            lock (_incomingLock)
                _incomingMessages.Add(new MessageTransportInfoWrapperMessage(info));
        }

        public MessageTransport.Error ReceiveMessages(List<MetaMessage> outputMessages)
        {
            var diff = DateTime.UtcNow - _previousUpdateAt;
            _previousUpdateAt = DateTime.UtcNow;

            if (diff > TimeSpan.FromSeconds(30))
            {
                TimeSpan watchdogDeadline;
                lock (_watchdogLock)
                    watchdogDeadline = _watchdogDeadlineLastDuration;
                SetWatchdog(watchdogDeadline);

                lock (_transportResetupLock)
                {
                    if (_resetupDeadlineAt.HasValue)
                        _resetupDeadlineAt = _previousUpdateAt + _resetupDeadlineLastDuration;
                }
            }

            var isBeyondDeadline = false;
            lock (_watchdogLock)
            {
                if (_enableWatchdog)
                    isBeyondDeadline = _previousUpdateAt > _watchdogDeadlineAt;
            }

            if (isBeyondDeadline)
            {
                MessageTransport.Error error;
                lock (_incomingLock)
                    error = _incomingError;

                if (error == null && _handshakePhase != ServerHandshakePhase.Error)
                {
                    // Log warning "Transport watchdog deadline exceeded. Killing transport."

                    var msg = new WatchdogDeadlineExceededError(ConnectionInternalWatchdogType.Transport);
                    var isResumed = TryStartResetupTransportForSessionResumption(msg);
                    if (!isResumed)
                        TerminateWithError(msg);
                    else
                        _reportWatchdogViolation?.Invoke();
                }

                DateTime? resetupDeadline;
                lock (_transportResetupLock)
                    resetupDeadline = _resetupDeadlineAt;

                if (resetupDeadline.HasValue)
                {
                    if (_previousUpdateAt > resetupDeadline.Value)
                    {
                        // Log warning "Resetup watchdog deadline exceeded. Killing transport."

                        TerminateWithError(new WatchdogDeadlineExceededError(ConnectionInternalWatchdogType.Resetup));
                    }
                }
            }

            lock (_incomingLock)
            {
                outputMessages.AddRange(_incomingMessages);
                _incomingMessages.Clear();
            }

            return _incomingError;
        }

        private bool TryStartResetupTransportForSessionResumption(MessageTransport.Error previousTransportError)
        {
            if (_currentSession == null)
                return false;

            var resumeInterval = TimeSpan.FromMilliseconds(_config.SessionResumptionAttemptConnectionInterval.Milliseconds);
            var ts = _currentSession.CurrentResumptionAttempt == null
                ? TimeSpan.Zero
                : DateTime.UtcNow - _currentSession.CurrentResumptionAttempt.StartTime;
            ts = resumeInterval - ts;

            var ts1 = _currentSession.CurrentResumptionAttempt == null ? TimeSpan.Zero : resumeInterval;
            if (ts < ts1)
            {
                // Log info "Session resumption attempt has taken {ts.TotalSeconds} sec already and the next connection attempt would happen after {ts1.TotalSeconds} sec, giving up"
                return false;
            }

            var t = 9;
            lock (_enqueueCloseLock)
            {
                if (!_closeEnqueued)
                {
                    RemoveTransport();
                    t = 10;
                }
            }

            if (t != 10)
                return false;

            StartResetupTransportForSessionResumption(previousTransportError, ts, ts1);
            return true;
        }

        private void RemoveTransport()
        {
            lock (_transportLock)
            {
                _transport.SetDebugDiagnosticsRef(null);

                _transport.OnConnect -= HandleOnConnect;
                _transport.OnError -= HandleOnError;
                _transport.OnReceive -= HandleOnReceive;
                _transport.OnInfo -= HandleOnInfo;
            }

            DisposeTransport();

            _handshakePhase = ServerHandshakePhase.NotConnected;
            EnqueueInfo(new TransportLifecycleInfo(false));
        }

        private void StartResetupTransportForSessionResumption(MessageTransport.Error previousTransportError, TimeSpan resumptionAttemptTimeRemaining, TimeSpan delayUntilResetup)
        {
            _currentSession.CurrentResumptionAttempt ??= new SessionResumptionAttempt(previousTransportError, DateTime.UtcNow);

            // Log Info "Will try to resume session after {DelaySeconds} sec, connection attempt {ConnectionAttemptIndex} (our info: {OurSessionInfo})"
            _currentGateway = ServerGatewayScheduler.SelectGatewayForConnectionResume(_endpoint, _currentGateway, _currentSession.CurrentResumptionAttempt.NumConnectionAttempts, _numSuccessfulSessionResumes);

            lock (_transportResetupLock)
            {
                _resetupDeadlineAt = DateTime.UtcNow + delayUntilResetup + TimeSpan.FromSeconds(5);
                _resetupDeadlineLastDuration = delayUntilResetup + TimeSpan.FromSeconds(5);
            }

            var maxConnectTimeout = resumptionAttemptTimeRemaining - delayUntilResetup + TimeSpan.FromMilliseconds(500);

            if (_transportResetupCancellation != null)
            {
                _transportResetupTask = Task.Run(() =>
                {
                    var isSetup = 3;
                    lock (_transportResetupLock)
                    {
                        _resetupDeadlineAt = null;
                        if (!_transportResetupCancellation.Token.IsCancellationRequested)
                        {
                            SetupTransport(maxConnectTimeout);
                            isSetup = 4;
                        }
                    }

                    if (isSetup != 3)
                        ; // Log debug "Re-setup of transport for session resumption started (maxConnectTimeout = {eh.TotalSeconds} sec)..."
                });
            }
        }

        private void HandleOnConnect(Handshake.ServerHello serverHello, MessageTransport.TransportHandshakeReport transportHandshake)
        {
            Interlocked.Increment(ref _connDiagnostics.HellosSent);
            Interlocked.Increment(ref _connDiagnostics.HellosReceived);

            _statistics.DurationToConnected = DateTime.UtcNow - _connectionStartTime;

            lock (_incomingLock)
            {
                var msg = new ConnectedToServer(transportHandshake.ChosenHostname, transportHandshake.ChosenProtocol == AddressFamily.InterNetwork, transportHandshake.TlsPeerDescription);
                _incomingMessages.Add(msg);
            }

            SetWatchdog(TimeSpan.FromSeconds(10));
            HandleOnReceiveServerHello(serverHello);
        }

        private void HandleOnError(MessageTransport.Error error)
        {
            // Log debug "Got error, connection lost {error}

            if (error != null)
            {
                if (error is WireMessageTransport.ProtocolStatusError pse)
                {
                    lock (_incomingLock)
                        _incomingMessages.Add(new ConnectionHandshakeFailure(pse.status));
                }
                else if (error is StreamMessageTransport.StreamClosedError sce)
                {
                    Interlocked.Increment(ref _connDiagnostics.StreamIOFailedErrors);
                }
                else if (error is StreamMessageTransport.StreamIOFailedError sfe)
                {
                    Interlocked.Increment(ref _connDiagnostics.StreamClosedErrors);
                }
                else if (error is StreamMessageTransport.StreamExecutorError see)
                {
                    Interlocked.Increment(ref _connDiagnostics.StreamExecutorErrors);
                }
                else if (error is WireMessageTransport.ConnectTimeoutError cte)
                {
                    Interlocked.Increment(ref _connDiagnostics.ConnectTimeoutErrors);
                }
                else if (error is WireMessageTransport.HeaderTimeoutError hte)
                {
                    Interlocked.Increment(ref _connDiagnostics.HeaderTimeoutErrors);
                }
                else if (error is WireMessageTransport.ReadTimeoutError rte)
                {
                    Interlocked.Increment(ref _connDiagnostics.ReadTimeoutErrors);
                }
                else if (error is WireMessageTransport.WriteTimeoutError wte)
                {
                    Interlocked.Increment(ref _connDiagnostics.WriteTimeoutErrors);
                }
                else
                {
                    Interlocked.Increment(ref _connDiagnostics.OtherErrors);
                }
            }

            if (!ErrorPermitsSessionResumption(error))
                if (!TryStartResetupTransportForSessionResumption(error))
                    TerminateWithError(error);
        }

        private static bool ErrorPermitsSessionResumption(MessageTransport.Error error)
        {
            if (error == null)
                return false;

            return error is TcpMessageTransport.CouldNotConnectError ||
                   error is TcpMessageTransport.ConnectionRefused ||
                   error is TlsMessageTransport.TlsError ||
                   error is StreamMessageTransport.StreamClosedError ||
                   error is StreamMessageTransport.StreamIOFailedError ||
                   error is StreamMessageTransport.StreamExecutorError ||
                   error is WireMessageTransport.ConnectTimeoutError ||
                   error is WireMessageTransport.TimeoutError;
        }

        private void HandleOnInfo(MessageTransport.Info info)
        {
            if (info != null)
            {
                if (info is WireMessageTransport.ThreadCycleUpdateInfo tcui)
                {
                    SetWatchdog(TimeSpan.FromSeconds(10));
                    return;
                }
            }

            if (_handshakePhase == ServerHandshakePhase.Error)
                return;

            EnqueueInfo(info);
        }

        private void HandleOnReceive(MetaMessage message)
        {
            switch (_handshakePhase)
            {
                case ServerHandshakePhase.InSession:
                    if (message is SessionForceTerminateMessage sftm)
                    {
                        // Log info "Got {message}"
                        TerminateWithError(new SessionForceTerminatedError(sftm.Reason));
                    }
                    else
                    {
                        Interlocked.Increment(ref _connDiagnostics.SessionMessagesReceived);

                        SessionUtil.ReceiveResult result;
                        lock (_currentSessionSendQueueLock)
                            result = SessionUtil.HandleReceive(_currentSession.SessionParticipant, message);

                        if (result == null)
                            throw new InvalidOperationException("Unknown ReceiveResult: null");

                        if (result is SessionUtil.ReceiveResult.HandleAck har)
                            OnHandledSessionAckFromServer(har.Value);
                        else if (result is SessionUtil.ReceiveResult.ReceivePayloadMessage rpm)
                        {
                            Interlocked.Increment(ref _connDiagnostics.SessionPayloadMessagesReceived);
                            OnSessionPayloadMessageReceivedFromServer(rpm.Value, message);
                        }
                        else
                            throw new InvalidOperationException($"Unknown ReceiveResult: {result.GetType()}");
                    }
                    break;

                case ServerHandshakePhase.WaitingForSessionHandshakeCompletion:
                    if (message is SessionProtocol.SessionStartSuccess sss)
                    {
                        HandleSessionStartSuccess(sss);
                    }
                    else if (message is SessionProtocol.SessionStartFailure ssf)
                    {
                        HandleSessionStartFailure(ssf);
                    }
                    else if (message is SessionProtocol.SessionResumeSuccess srs)
                    {
                        HandleSessionResumeSuccess(srs);
                    }
                    else if (message is SessionProtocol.SessionResumeFailure srf)
                    {
                        HandleSessionResumeFailure(srf);
                    }
                    else if (message is Handshake.OperationStillOngoing opo)
                        break;
                    else
                    {
                        // Log debug "Expected session response, got {message.GetType()}"
                        TerminateWithError(new UnexpectedLoginMessageError(message.GetType().Name));
                    }

                    break;

                case ServerHandshakePhase.WaitingForLoginCompletion:
                    if (message is Handshake.LoginResponse lr)
                    {
                        HandleLoginResponse(lr);
                    }
                    else if (message is Handshake.LogicVersionMismatch lvm)
                    {
                        HandleLogicVersionMismatch(lvm);
                    }
                    else if (message is Handshake.RedirectToServer rts)
                    {
                        HandleRedirectToServer(rts);
                    }
                    else if (message is Handshake.LoginFailureDueToMaintenanceResponse lfr)
                    {
                        HandleMaintenanceModeFailure(lfr);
                    }
                    else if (message is Handshake.SocialAuthenticationLoginFailure sar)
                    {
                        HandleSocialAuthenticationLoginFailure(sar);
                    }
                    else if (message is Handshake.OperationStillOngoing opo)
                        break;
                    else
                    {
                        // Log debug "Expected login response, got {message}"
                        TerminateWithError(new UnexpectedLoginMessageError(message.GetType().Name));
                    }

                    break;

                case ServerHandshakePhase.Error:
                    return;
            }

            var isFiltered = _earlyMessageFilterSyncFn?.Invoke(message) ?? false;
            if (!isFiltered)
            {
                lock (_incomingLock)
                    _incomingMessages.Add(message);
            }
        }

        private void OnHandledSessionAckFromServer(SessionUtil.ValidateAckResult result)
        {
            if (result == null)
                throw new InvalidOperationException("Unknown ValidateAckResult: null");

            if (result is SessionUtil.ValidateAckResult.Success s)
                return;

            if (result is SessionUtil.ValidateAckResult.Failure f)
            {
                TerminateWithError(new SessionError($"Session acknowledgement failure: {f}"));
            }
            else
                throw new InvalidOperationException($"Unknown ValidateAckResult: {result.GetType().Name}");
        }

        private void OnSessionPayloadMessageReceivedFromServer(SessionUtil.ReceivePayloadMessageResult result, MetaMessage payloadMessage)
        {
            if (!result.ShouldSendAcknowledgement)
                return;

            var sesAck = SessionAcknowledgement.FromParticipantState(_currentSession.SessionParticipant);
            var msg = new SessionAcknowledgementMessage(sesAck);

            _transport.EnqueueSendMessage(msg);
        }

        private void HandleSessionStartSuccess(SessionProtocol.SessionStartSuccess sessionSuccess)
        {
            if (_currentSession != null)
            {
                TerminateWithError(new SessionError("Tried to start new session but we already have a session"));
                return;
            }

            if (sessionSuccess.QueryId != _currentSessionStartQueryId)
            {
                TerminateWithError(new SessionError($"Got session start success response for stale request. Got id {sessionSuccess.QueryId}, expected {_currentSessionStartQueryId}"));
                return;
            }

            // Log info "Session created, token {sessionSuccess.SessionToken}"
            lock (_currentSessionSendQueueLock)
            {
                var state = new SessionParticipantState(sessionSuccess.SessionToken);
                _currentSession = new SessionState(state);

                _handshakePhase = ServerHandshakePhase.InSession;
            }
        }

        private void HandleSessionStartFailure(SessionProtocol.SessionStartFailure sessionFailure)
        {
            switch (sessionFailure.Reason)
            {
                case SessionProtocol.SessionStartFailure.ReasonCode.InternalError:
                    // Log warning "Failed to start session. Provided message: <no message>"
                    TerminateWithError(new SessionStartFailed(sessionFailure.DebugOnlyErrorMessage));
                    break;

                case SessionProtocol.SessionStartFailure.ReasonCode.ResourceCorrection:
                    if (sessionFailure.QueryId == _currentSessionStartQueryId)
                        EnqueueInfo(new ResourceCorrectionInfo(sessionFailure.ResourceCorrection));
                    else
                        ; // Log debug "Session resource correction request was stale, ignored. Got id {sessionFailure.QueryId}, expected {_currentSessionStartQueryId}"

                    break;

                case SessionProtocol.SessionStartFailure.ReasonCode.Banned:
                    TerminateWithError(new PlayerIsBannedError());
                    break;

                case SessionProtocol.SessionStartFailure.ReasonCode.PlayerDeserializationFailure:
                    TerminateWithError(new PlayerDeserializationFailureError(sessionFailure.DebugOnlyErrorMessage ?? "deserialization failure"));
                    break;

                case SessionProtocol.SessionStartFailure.ReasonCode.WrongAuthenticationPlatform:
                    TerminateWithError(new UsingWrongAuthenticationMethodError());
                    break;

                default:
                    return;
            }
        }

        private void HandleSessionResumeFailure(SessionProtocol.SessionResumeFailure failed)
        {
            // Log warning "Session resumption failure"
            TerminateWithError(new SessionResumeFailed());
        }

        private void HandleLogicVersionMismatch(Handshake.LogicVersionMismatch versionMismatch)
        {
            // Log warning "Client LogicVersion is too old for server: clientSupportedLogicVersions={MetaplayCore.Options.SupportedLogicVersions}, serverAcceptedLogicVersions={versionMismatch.ServerAcceptedLogicVersions.MinVersion}..{versionMismatch.ServerAcceptedLogicVersions.MaxVersion}
            TerminateWithError(new LogicVersionMismatchError(MetaplayCore.Options.SupportedLogicVersions, versionMismatch.ServerAcceptedLogicVersions));
        }

        private void HandleRedirectToServer(Handshake.RedirectToServer redirect)
        {
            if (redirect.RedirectToEndpoint == null)
            {
                // Log error "Redirecting to null server!"
            }
            else
            {
                // Log info "Redirecting to server {redirect.RedirectToEndpoint.ServerHost}:{redirect.RedirectToEndpoint.ServerPort} tls={redirect.RedirectToEndpoint.EnableTls} (CdnBaseUrl={redirect.RedirectToEndpoint.CdnBaseUrl})"
            }

            TerminateWithError(new RedirectToServerError(redirect.RedirectToEndpoint));
        }

        private void HandleMaintenanceModeFailure(Handshake.LoginFailureDueToMaintenanceResponse maintenanceFailure)
        {
            // Log warning "Server is currently ongoing maintenance!"
            TerminateWithError(new MaintenanceModeOngoingError());
        }

        private void HandleSocialAuthenticationLoginFailure(Handshake.SocialAuthenticationLoginFailure socialAuthFailure)
        {
            // Log warning "Login via social authentication credentials failed!"
            TerminateWithError(new SocialAuthenticationLoginFailedError());
        }

        private void HandleSessionResumeSuccess(SessionProtocol.SessionResumeSuccess sessionResume)
        {
            if (_currentSession == null)
            {
                TerminateWithError(new SessionError("Got resume session but don't have a session"));
                return;
            }

            // Log info "Session resume successful, token {sessionResume.SessionToken}, server session acknowledgement {sessionResume.ServerSessionAcknowledgement}"
            lock (_currentSessionSendQueueLock)
            {
                var info = new SessionResumptionInfo(sessionResume.SessionToken, sessionResume.ServerSessionAcknowledgement);
                var result = SessionUtil.HandleResume(_currentSession?.SessionParticipant, info);

                if (result == null)
                    throw new InvalidOperationException("Unknown ResumeResult: null");

                if (result is SessionUtil.ResumeResult.Success s)
                {
                    _currentSession.CurrentResumptionAttempt = null;

                    foreach (var msg in _currentSession.SessionParticipant.RememberedSent)
                        _transport.EnqueueSendMessage(msg);

                    Interlocked.Add(ref _connDiagnostics.SessionMessagesDelayedSent, _currentSession.SessionParticipant.RememberedSent.Count);
                }
                else if (result is SessionUtil.ResumeResult.Failure f)
                {
                    TerminateWithError(new SessionError($"session resume payload could not be applied: {f}"));
                }
                else
                    throw new InvalidOperationException($"Unknown ResumeResult: {result.GetType().Name}");
            }

            // Log info "Resumed session: {sessionResume.GetType().Name}, and sending Re-sending {_currentSession.SessionParticipant.RememberedSent.Count} unacknowledged session payload messages"
            _numSuccessfulSessionResumes++;
        }

        private void HandleLoginResponse(Handshake.LoginResponse loginResponse)
        {
            Interlocked.Increment(ref _connDiagnostics.LoginSuccessesReceived);
            _connDiagnostics.LastLoginSuccessReceivedAtMS = MetaTime.Now.MillisecondsSinceEpoch;

            // Log info "Successfully logged in"

            if (_credentials.SocialAuthClaim == null)
            {
                if (!string.IsNullOrEmpty(_credentials.DeviceId))
                {
                    if (loginResponse.PlayerId.IsValid)
                    {
                        if (_credentials.PlayerId == loginResponse.PlayerId)
                        {
                            // Log warning "Server corrected PlayerId but correction did not change it!"
                        }
                        else
                        {
                            _credentials = new LoginCredentials(_credentials.DeviceId, _credentials.AuthToken, loginResponse.PlayerId, _credentials.IsBot, null);
                            EnqueueInfo(new LoginCredentialsChangedInfo(LoginCredentialsChangedInfo.ChangeType.PlayerIdChanged, _credentials.DeviceId, _credentials.AuthToken, loginResponse.PlayerId));
                        }
                    }
                }
                else
                {
                    if (loginResponse.DeviceId == null)
                    {
                        TerminateWithError(new SessionError("Newly created player must receive DeviceId from server"));
                        return;
                    }

                    if (loginResponse.AuthToken == null)
                    {
                        TerminateWithError(new SessionError("Newly created player must receive AuthToken from server"));
                        return;
                    }

                    if (!loginResponse.PlayerId.IsValid)
                    {
                        TerminateWithError(new SessionError("Newly created player must receive PlayerId from server"));
                        return;
                    }

                    _credentials = new LoginCredentials(loginResponse.DeviceId, loginResponse.AuthToken, loginResponse.PlayerId, _credentials.IsBot, null);
                    EnqueueInfo(new LoginCredentialsChangedInfo(LoginCredentialsChangedInfo.ChangeType.CredentialsCreated, loginResponse.DeviceId, loginResponse.AuthToken, loginResponse.PlayerId));
                }
            }
            else
            {
                var deviceId = loginResponse.DeviceId;
                if (deviceId == null && loginResponse.PlayerId.IsValid)
                    deviceId = _credentials.DeviceId;

                var playerId = loginResponse.PlayerId.IsValid ? loginResponse.PlayerId : _credentials.PlayerId;

                _credentials = new LoginCredentials(deviceId, _credentials.AuthToken, playerId, _credentials.IsBot, _credentials.SocialAuthClaim);

                EnqueueInfo(new LoginCredentialsChangedInfo(LoginCredentialsChangedInfo.ChangeType.PlayerIdChanged, deviceId, _credentials.AuthToken, playerId));
            }

            _statistics.DurationToLoginSuccess = DateTime.UtcNow - _connectionStartTime;
            _handshakePhase = ServerHandshakePhase.WaitingForSessionHandshakeCompletion;
        }

        private void HandleOnReceiveServerHello(Handshake.ServerHello serverHello)
        {
            var msg = new GotServerHello(serverHello);
            EnqueueInfo(msg);

            if (serverHello.FullProtocolHash != MetaSerializerTypeRegistry.FullProtocolHash)
                EnqueueInfo(new FullProtocolHashMismatchInfo(MetaSerializerTypeRegistry.FullProtocolHash, serverHello.FullProtocolHash));

            var isClientCommitValid = !string.IsNullOrEmpty(_buildVersion.CommitId) && _buildVersion.CommitId != "undefined";
            var isServerCommitValid = !string.IsNullOrEmpty(serverHello.CommitId) && serverHello.CommitId != "undefined";

            var isValidCommitCheck = true;
            if (_config.CommitIdCheckRule != ClientServerCommitIdCheckRule.Strict)
                isValidCommitCheck = isClientCommitValid & isServerCommitValid & _config.CommitIdCheckRule == ClientServerCommitIdCheckRule.OnlyIfDefined;

            if (isValidCommitCheck && (_buildVersion.CommitId == serverHello.CommitId & isClientCommitValid & isServerCommitValid) == false)
            {
                // If commit check failed, terminate
                TerminateWithError(new CommitIdMismatchMismatchError(_buildVersion.CommitId, serverHello.CommitId));
            }
            else
            {
                // Send login request
                var loginDiag = _getDebugDiagnostics(_currentSession != null);
                var loginMsg = _credentials.SocialAuthClaim == null ?
                    (MetaMessage)new Handshake.DeviceLoginRequest(_credentials.DeviceId, _credentials.AuthToken, _credentials.PlayerId, _credentials.IsBot, loginDiag, _config.LoginGamePayload) :
                    new Handshake.SocialAuthenticationLoginRequest(_credentials.SocialAuthClaim, _credentials.AuthToken, _credentials.PlayerId, _credentials.IsBot, loginDiag, _config.LoginGamePayload);

                _transport.EnqueueSendMessage(loginMsg);

                var sessionReq = _currentSession == null ?
                    (MetaMessage)new SessionProtocol.SessionStartRequest(++_currentSessionStartQueryId, _config.DeviceModel, GetPlayerTimeZoneInfo(), _resourceProposal, false, _config.SessionStartGamePayload, CompressUtil.GetSupportedDecompressionAlgorithms(), _clientAppPauseStatus) :
                    new SessionProtocol.SessionResumeRequest(SessionResumptionInfo.FromParticipantState(_currentSession.SessionParticipant));

                _transport.EnqueueSendMessage(sessionReq);

                if (_currentSession != null)
                    Interlocked.Increment(ref _connDiagnostics.ResumptionLoginsSent);
                else
                    Interlocked.Increment(ref _connDiagnostics.InitialLoginsSent);

                _handshakePhase = ServerHandshakePhase.WaitingForLoginCompletion;
            }
        }

        private static PlayerTimeZoneInfo GetPlayerTimeZoneInfo()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
            var metaOffset = MetaDuration.FromMilliseconds((long)offset.TotalMilliseconds);

            return new PlayerTimeZoneInfo(metaOffset);
        }

        private void TerminateWithError(MessageTransport.Error error)
        {
            _handshakePhase = ServerHandshakePhase.Error;

            lock (_currentSessionSendQueueLock)
                _currentSession = null;

            lock (_incomingLock)
            {
                _incomingMessages.Add(new DisconnectedFromServer());
                _incomingError = error;
            }

            DisposeWithCause(error);
        }

        private void DisposeWithCause(MessageTransport.Error error)
        {
            DisposeTransport();

            //lock (_pauseTerminationTimerLock)
            //    _pauseTerminationTimer.Dispose();
            //_pauseTerminationTimer = null;

            _terminatingErrorTask.TrySetResult(error);
        }

        private void DisposeTransport()
        {
            lock (_transportLock)
            {
                _transport.Dispose();
                _transport = null;
            }
        }

        #region Delegates

        public delegate IMessageTransport CreateTransportFn(ServerGateway serverGateway, TimeSpan? maxConnectTimeout);

        public delegate LoginDebugDiagnostics GetDebugDiagnosticsFn(bool isSessionResumption);

        public delegate bool EarlyMessageFilterSyncFn(MetaMessage msg);

        #endregion

        #region Classes

        public class Config
        {
            // Fields
            public MetaDuration SessionResumptionAttemptMaxDuration; // 0x10
            public MetaDuration SessionResumptionAttemptConnectionInterval; // 0x18
            public MetaDuration ConnectTimeout; // 0x20
            public ClientServerCommitIdCheckRule CommitIdCheckRule; // 0x28
            public string DeviceModel; // 0x30
            public Handshake.ILoginRequestGamePayload LoginGamePayload; // 0x38
            public SessionProtocol.ISessionStartRequestGamePayload SessionStartGamePayload; // 0x40
        }

        private class SessionState
        {
            public SessionParticipantState SessionParticipant { get; } // 0x10
            public SessionResumptionAttempt CurrentResumptionAttempt { get; set; } // 0x18

            public SessionState(SessionParticipantState sessionParticipant)
            {
                SessionParticipant = sessionParticipant;
            }
        }

        public class SessionResumptionAttempt
        {
            public MessageTransport.Error PreviousTransportError; // 0x10
            public DateTime StartTime; // 0x18
            public int NumConnectionAttempts; // 0x20

            public SessionResumptionAttempt(MessageTransport.Error previousTransportError, DateTime startTime)
            {
                PreviousTransportError = previousTransportError;
                StartTime = startTime;
            }
        }

        public struct Stats
        {
            public TimeSpan DurationToConnected; // 0x0
            public TimeSpan DurationToLoginSuccess; // 0x8
        }

        public enum ServerHandshakePhase
        {
            NotConnected = 0,
            WaitingForLoginCompletion = 1,
            WaitingForSessionHandshakeCompletion = 2,
            InSession = 3,
            Error = 4
        }

        #endregion

        #region Messages

        public class CommitIdMismatchMismatchError : MessageTransport.Error
        {
            public string ClientCommitId { get; } // 0x10
            public string ServerCommitId { get; } // 0x18

            public CommitIdMismatchMismatchError(string clientCommitId, string serverCommitId)
            {
                ClientCommitId = clientCommitId;
                ServerCommitId = serverCommitId;
            }
        }

        public class WatchdogDeadlineExceededError : MessageTransport.Error
        {
            public ConnectionInternalWatchdogType WatchdogType { get; } // 0x10

            public WatchdogDeadlineExceededError(ConnectionInternalWatchdogType watchdogType)
            {
                WatchdogType = watchdogType;
            }
        }

        public class SessionForceTerminatedError : MessageTransport.Error
        {
            public SessionForceTerminateReason Reason { get; } // 0x10

            public SessionForceTerminatedError(SessionForceTerminateReason reason)
            {
                Reason = reason;
            }
        }

        public class UnexpectedLoginMessageError : MessageTransport.Error
        {
            public string MessageType { get; } // 0x10

            public UnexpectedLoginMessageError(string type)
            {
                MessageType = type;
            }
        }

        public class SessionError : MessageTransport.Error
        {
            public string Reason { get; } // 0x10

            public SessionError(string reason)
            {
                Reason = reason;
            }
        }

        public class SessionStartFailed : MessageTransport.Error
        {
            public string Message { get; } // 0x10

            public SessionStartFailed(string message)
            {
                Message = message;
            }
        }

        public class PlayerIsBannedError : MessageTransport.Error
        {
        }

        public class PlayerDeserializationFailureError : MessageTransport.Error
        {
            public string Error { get; } // 0x10

            public PlayerDeserializationFailureError(string error)
            {
                Error = error;
            }
        }

        public class UsingWrongAuthenticationMethodError : MessageTransport.Error
        {
        }

        public class SessionResumeFailed : MessageTransport.Error
        {
        }

        public class LogicVersionMismatchError : MessageTransport.Error
        {
            public MetaVersionRange ClientSupportedVersions { get; } // 0x10
            public MetaVersionRange ServerAcceptedVersions { get; } // 0x18

            public LogicVersionMismatchError(MetaVersionRange clientSupportedVersions,
                MetaVersionRange serverAcceptedVersions)
            {
                ClientSupportedVersions = clientSupportedVersions;
                ServerAcceptedVersions = serverAcceptedVersions;
            }
        }

        public class RedirectToServerError : MessageTransport.Error
        {
            public ServerEndpoint RedirectToServer { get; } // 0x10

            public RedirectToServerError(ServerEndpoint redirectToServer)
            {
                RedirectToServer = redirectToServer;
            }
        }

        public class MaintenanceModeOngoingError : MessageTransport.Error
        {
        }

        public class SocialAuthenticationLoginFailedError : MessageTransport.Error
        {
        }

        public class GotServerHello : MessageTransport.Info
        {
            public Handshake.ServerHello ServerHello { get; } // 0x10

            public GotServerHello(Handshake.ServerHello serverHello)
            {
                ServerHello = serverHello;
            }
        }

        public class FullProtocolHashMismatchInfo : MessageTransport.Info
        {
            public uint ClientProtocolHash { get; } // 0x10
            public uint ServerProtocolHash { get; } // 0x14

            public FullProtocolHashMismatchInfo(uint clientProtocolHash, uint serverProtocolHash)
            {
                ClientProtocolHash = clientProtocolHash;
                ServerProtocolHash = serverProtocolHash;
            }
        }

        public class TransportLifecycleInfo : MessageTransport.Info
        {
            public bool IsTransportAttached { get; } // 0x10

            public TransportLifecycleInfo(bool isTransportAttached)
            {
                IsTransportAttached = isTransportAttached;
            }
        }

        public class ResourceCorrectionInfo : MessageTransport.Info
        {
            public readonly SessionProtocol.SessionResourceCorrection ResourceCorrection; // 0x10

            public ResourceCorrectionInfo(SessionProtocol.SessionResourceCorrection resourceCorrection)
            {
                ResourceCorrection = resourceCorrection;
            }
        }

        public class LoginCredentialsChangedInfo : MessageTransport.Info
        {
            public readonly ChangeType Change; // 0x10
            public readonly string DeviceId; // 0x18
            public readonly string AuthToken; // 0x20
            public readonly EntityId PlayerId; // 0x28

            public LoginCredentialsChangedInfo(ChangeType change, string deviceId, string authToken, EntityId playerId)
            {
                Change = change;
                DeviceId = deviceId;
                AuthToken = authToken;
                PlayerId = playerId;
            }

            public enum ChangeType
            {
                PlayerIdChanged = 0,
                CredentialsCreated = 1
            }
        }

        #endregion
    }
}

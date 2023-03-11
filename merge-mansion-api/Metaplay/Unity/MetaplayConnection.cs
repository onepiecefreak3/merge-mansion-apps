using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Metaplay.Client.Messages;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Client;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Debugging;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core.Player;
using Metaplay.Metaplay.Core.Serialization;
using Metaplay.Metaplay.Core.Session;
using Metaplay.Metaplay.Network;
using Metaplay.Metaplay.Unity.ConnectionStates;
using Metaplay.UnityEngine;
using Newtonsoft.Json;

namespace Metaplay.Metaplay.Unity
{
    public sealed class MetaplayConnection
    {
        public ConnectionConfig Config; // 0x30

        public ClientSessionStartResources SessionStartResources; // 0x60

        private DeviceCredentials _credentials; // 0x70
        private bool _credentialsPendingIOError; // 0x78
        private ServerConnection _serverConnection; // 0x80
        private IEnumerator<Marker> _supervisionLoop; // 0x88
        private CancellationTokenSource _cancellation; // 0x90
        private bool _flushEnqueuedMessagesBeforeClose; // 0x98
        private bool _supervisionLoopRunning; // 0x99
        private List<MetaMessage> _messagesToDispatch; // 0xA0
        private ConnectionStatistics _statistics; // 0xA8
        private IMetaplayConnectionSDKHook _sdkHook; // 0xB0
        private uint _sessionConnectionNdx; // 0xB8
        private uint _sessionNonce; // 0xBC
        private bool _messageDispatchSuspended; // 0xC0
        private List<MetaMessage> _suspendedDispatchMessages; // 0xC8
        //private LogHandlerForwardingBuffer _logForwardingBuffer; // 0xD0
        //private LogChannel _logForwardingChannel; // 0xD8
        private MetaplayOfflineOptions _offlineOptions; // 0xE0

        // 0x10
        // private LogChannel Log { get; }
        // 0x18
        public IMetaplayConnectionDelegate Delegate { get; }
        // 0x20
        public ServerEndpoint Endpoint { get; set; }
        // 0x28
        public ConnectionState State { get; set; }

        // 0x38
        public string LatestTlsPeerDescription { get; set; }
        // 0x40
        public ConnectionGameConfigInfo LatestGameConfigInfo { get; set; }
        // 0x48
        public string LatestServerVersion { get; set; }
        // 0x50
        public SessionProtocol.ServerOptions ServerOptions { get; set; }

        // 0x68
        public IOfflineServer OfflineServer { get; set; }

        private MetaDuration? JustEndedPauseDuration => MetaplaySDK.ApplicationPauseStatus == ApplicationPauseStatus.ResumedFromPauseThisFrame ? MetaplaySDK.ApplicationLastPauseDuration : (MetaDuration?)null;
        private bool ShouldEndSessionDueToRecentPause => JustEndedPauseDuration.HasValue && JustEndedPauseDuration.Value > MetaplaySDK.ApplicationPauseMaxDuration;

        internal MetaplayConnection(ServerEndpoint initialEndpoint, ConnectionConfig config,
            IMetaplayConnectionDelegate connDelegate, IMetaplayConnectionSDKHook sdkHook,
            MetaplayOfflineOptions offlineOptions)
        {
            _suspendedDispatchMessages = new List<MetaMessage>();

            Delegate = connDelegate;
            Endpoint = initialEndpoint;
            _sdkHook = sdkHook;
            //Log = MetaplaySDK.IncidentTracker;
            _offlineOptions = offlineOptions;

            State = new NotConnected();
            Config = config ?? new ConnectionConfig();

            _supervisionLoopRunning = false;
            _supervisionLoop = null;
            _cancellation = null;
            _serverConnection = null;

            _messagesToDispatch = new List<MetaMessage>();
            _statistics = ConnectionStatistics.CreateNew();
            //_logForwardingBuffer = new LogHandlerForwardingBuffer(Log, 100, TimeSpan.FromSeconds(5));
            //_logForwardingChannel = new LogChannel(Log.0x10, new List<ILogHandler>{ _logForwardingBuffer });

            Delegate.Init();

            _credentials = CredentialsStore.TryGetCredentials(out _credentialsPendingIOError);
            if (_credentials == null)
            {
                // Log info "Registering new device"
                _credentials = new DeviceCredentials
                {
                    DeviceId = null,
                    AuthToken = null,
                    PlayerId = EntityId.None
                };
            }

            // Log debug "Found device credentials: deviceId={_credentials.DeviceId}, playerId={_credentials.PlayerId}"
        }

        //public Task<ISharedGameConfig> GetSpecializedGameConfigAsync(ContentHash configVersion, ContentHash patchesVersion, GameConfigSpecializationKey specializationKey)
        //{
        //    return GetSpecializedGameConfigAsync(configVersion, patchesVersion, specializationKey, CancellationToken.None);
        //}

        //public Task<ISharedGameConfig> GetSpecializedGameConfigAsync(ContentHash configVersion, ContentHash patchesVersion, Dictionary<PlayerExperimentId, ExperimentVariantId> experimentAssignment)
        //{
        //    return GetSpecializedGameConfigAsync(configVersion, patchesVersion, experimentAssignment, CancellationToken.None);
        //}

        //public async Task<ISharedGameConfig> GetSpecializedGameConfigAsync(ContentHash configVersion, ContentHash patchesVersion, GameConfigSpecializationKey specializationKey, CancellationToken ct)
        //{
        //    var configArchive = await DownloadConfigArchiveAsync("SharedGameConfig", configVersion, null, ct);
        //    var patches = await DownloadConfigPatchesAsync(patchesVersion, ct);

        //    if (patches == null)
        //    {
        //        var patchedArchive = PatchedConfigArchive.WithNoPatches(configArchive);
        //        return GameConfigFactory.Instance.ImportSharedGameConfig(patchedArchive);
        //    }
        //    else
        //    {
        //        var envelopes = patches.GetPatchesForSpecialization(specializationKey);
        //        var patchedArchive = new PatchedConfigArchive(configArchive, envelopes);

        //        return GameConfigFactory.Instance.ImportSharedGameConfig(patchedArchive);
        //    }
        //}

        //public async Task<ISharedGameConfig> GetSpecializedGameConfigAsync(ContentHash configVersion, ContentHash patchesVersion, Dictionary<PlayerExperimentId, ExperimentVariantId> experimentAssignment, CancellationToken ct)
        //{
        //    var configArchive = await DownloadConfigArchiveAsync("SharedGameConfig", configVersion, null, ct);
        //    var patches = await DownloadConfigPatchesAsync(patchesVersion, ct);

        //    if (patches == null)
        //    {
        //        var patchedArchive = PatchedConfigArchive.WithNoPatches(configArchive);
        //        return GameConfigFactory.Instance.ImportSharedGameConfig(patchedArchive);
        //    }
        //    else
        //    {
        //        var key = patches.CreateKeyFromAssignment(experimentAssignment);
        //        var envelopes = patches.GetPatchesForSpecialization(key);
        //        var patchedArchive = new PatchedConfigArchive(configArchive, envelopes);

        //        return GameConfigFactory.Instance.ImportSharedGameConfig(patchedArchive);
        //    }
        //}

        public LoginSessionDebugDiagnostics TryGetLoginSessionDebugDiagnostics()
        {
            return _serverConnection?.TryGetLoginSessionDebugDiagnostics();
        }

        public LoginServerConnectionDebugDiagnostics TryGetLoginServerConnectionDebugDiagnostics()
        {
            return _serverConnection?.GetLoginServerConnectionDebugDiagnostics();
        }

        public LoginTransportDebugDiagnostics TryGetLoginTransportDebugDiagnostics()
        {
            return _serverConnection?.GetLoginTransportDebugDebugDiagnostics();
        }

        public void Connect()
        {
            if (_cancellation != null)
                throw new InvalidOperationException($"must be NotConnected to call Connect(), but is {State?.Status}. See Reconnect()");

            _cancellation = new CancellationTokenSource();
            _messageDispatchSuspended = false;

            _supervisionLoop = SupervisionLoop(_cancellation.Token);
            _supervisionLoop.MoveNext();
        }

        private async Task<ServerConnection> CreateConnection(SessionProtocol.SessionResourceProposal initialResourceProposal, ClientAppPauseStatus initialPauseStatus)
        {
            var numFailedConnectionAttempts = 0;
            if (State is Connecting con)
                numFailedConnectionAttempts = con.ConnectionAttempt;

            var serverConnectionConfig = new ServerConnection.Config
            {
                SessionResumptionAttemptMaxDuration = Config.SessionResumptionAttemptMaxDuration,
                SessionResumptionAttemptConnectionInterval = Config.SessionResumptionAttemptConnectionInterval,
                ConnectTimeout = Config.ConnectTimeout,
                CommitIdCheckRule = Config.CommitIdCheckRule,
                DeviceModel = SystemInfo.DeviceModel,
                LoginGamePayload = Delegate.GetLoginPayload(),
                SessionStartGamePayload = Delegate.GetSessionStartRequestPayload()
            };

            ServerConnection.CreateTransportFn createTransport;
            if (!Endpoint.IsOfflineMode)
                createTransport = CreateOnlineTransport;
            else
            {
                var offlineServer = OfflineServer = IntegrationRegistry.Create<IOfflineServer>();
                await OfflineServer.InitializeAsync();

                createTransport = (gateway, timeout) => offlineServer;
            }

            var creds = Delegate.GetSocialAuthLoginCredentials();
            if (creds != null)
                ; // Log debug "Using social authentication credentials: platform={creds.Platform}"

            var loginCreds = new LoginCredentials(_credentials.DeviceId, _credentials.AuthToken, _credentials.PlayerId, false, creds);

            return new ServerConnection(serverConnectionConfig, Endpoint, createTransport, MetaplaySDK.BuildVersion,
                loginCreds, initialResourceProposal, initialPauseStatus, Delegate.GetLoginDebugDiagnostics, MetaplaySDK.MessageDispatcher.InterceptMessage,
                true, MetaplaySDK.IncidentTracker.ReportWatchdogDeadlineExceededError, numFailedConnectionAttempts);
        }

        private IMessageTransport CreateOnlineTransport(ServerGateway gateway, TimeSpan? maxConnectTimeout)
        {
            // Define correct timeout
            var timeout = Config.ConnectTimeout == MetaDuration.Zero ?
                TimeSpan.FromMilliseconds(-1) :
                Config.ConnectTimeout.ToTimeSpan();

            if (maxConnectTimeout.HasValue)
            {
                if (timeout == TimeSpan.FromMilliseconds(-1) || timeout > maxConnectTimeout.Value)
                    timeout = maxConnectTimeout.Value;
            }

            // Set up transport config
            var tcpTransport = !gateway.EnableTls ? new TcpMessageTransport(null) : new TlsMessageTransport(null);
            var transportConfig = tcpTransport.Config();

            transportConfig.GameMagic = MetaplayCore.Options.GameMagic;
            transportConfig.Version = MetaplaySDK.BuildVersion.Version;
            transportConfig.BuildNumber = MetaplaySDK.BuildVersion.BuildNumber;
            transportConfig.SupportedLogicVersions = MetaplayCore.Options.SupportedLogicVersions;
            transportConfig.FullProtocolHash = MetaSerializerTypeRegistry.FullProtocolHash;
            transportConfig.CommitId = MetaplaySDK.BuildVersion.CommitId;
            transportConfig.ClientSessionConnectionNdx = _sessionConnectionNdx;
            transportConfig.ClientSessionNonce = _sessionNonce;
            transportConfig.AppLaunchId = BitConverter.ToUInt32(MetaplaySDK.AppLaunchId.ToByteArray());
            transportConfig.Platform = ClientPlatform.Android;
            transportConfig.LoginProtocolVersion = MetaplayCore.Options.LoginProtocolVersion;
            transportConfig.ConnectTimeout = timeout;
            transportConfig.HeaderReadTimeout = Config.ServerIdentifyTimeout == MetaDuration.Zero ?
                TimeSpan.FromMilliseconds(-1) :
                Config.ServerIdentifyTimeout.ToTimeSpan();
            transportConfig.DnsCacheMaxTTL = TimeSpan.FromMinutes(5);
            transportConfig.ServerHostIPv4 = MetaplayHostnameUtil.GetV4V6SpecificHost(gateway.ServerHost, true);
            transportConfig.ServerHostIPv6 = MetaplayHostnameUtil.GetV4V6SpecificHost(gateway.ServerHost, false);
            transportConfig.ServerPort = gateway.ServerPort;

            // Log info "Opening connection to {ServerHost}:{ServerPort} (tls={EnableTls})"

            _sessionConnectionNdx++;

            return tcpTransport;
        }

        internal void InternalUpdate()
        {
            Delegate.Update();
            OfflineServer?.Update();
            UpdateSupervisor();
        }

        private void UpdateSupervisor()
        {
            if (!_messageDispatchSuspended)
                DispatchSuspendedMessages();

            var stepped = StepSupervisor(out var marker);
            do
            {
                if (!stepped)
                    return;

                if (!_messageDispatchSuspended)
                    DispatchSuspendedMessages();

                foreach (var msg in _messagesToDispatch)
                {
                    if (!_messageDispatchSuspended)
                        MetaplaySDK.MessageDispatcher.OnReceiveMessage(msg);
                    else
                        _suspendedDispatchMessages.Add(msg);
                }

                _messagesToDispatch.Clear();

                if (marker != Marker.HandleMessagesAndCallAgain)
                    return;

                stepped = StepSupervisor(out marker);
            } while (true);
        }

        private void DispatchSuspendedMessages()
        {
            foreach (var msg in _suspendedDispatchMessages)
                MetaplaySDK.MessageDispatcher.OnReceiveMessage(msg);

            _suspendedDispatchMessages.Clear();
        }

        private bool StepSupervisor(out Marker marker)
        {
            marker = Marker.UpdateComplete;
            if (_supervisionLoop == null)
                return false;

            _supervisionLoopRunning = true;
            _messagesToDispatch.Clear();

            var next = _supervisionLoop.MoveNext();
            marker = _supervisionLoop.Current;

            return next;
        }

        private IEnumerator<Marker> SupervisionLoop(CancellationToken ct)
        {
            /*	private int <>1__state; // 0x10
	            private MetaplayConnection.Marker <>2__current; // 0x14
	            public MetaplayConnection <>4__this; // 0x18
	            public CancellationToken ct; // 0x20
	            private List<MetaMessage> <messageBuffer>5__2; // 0x28
	            private List<MetaMessage> <delayedLoginMessageBuffer>5__3; // 0x30
	            private TransportQosMonitor <qosMonitor>5__4; // 0x38
	            private int <numConnectAttempts>5__5; // 0x40
	            private MetaTime <latestMessagesTimestamp>5__6; // 0x48
	            private Task<NetworkDiagnosticReport> <networkDiagnosticReportTask>5__7; // 0x50
	            private Task<MetaplayConnection.ServerStatusHint> <serverStatusHintFetchTask>5__8; // 0x58
	            private ConnectionState <cannotConnectError>5__9; // 0x60
	            private ConnectionState <sessionStartError>5__10; // 0x68
	            private MetaplayConnection.ConfigResourceLoader <configResourceLoader>5__11; // 0x70
	            private List<MetaplayConnection.SessionResourceLoader> <sessionResourceLoaders>5__12; // 0x78
	            private ScheduledMaintenanceMode <latestConnectionScheduledMaintenanceMode>5__13; // 0x80
	            private Handshake.ConnectionOptions <latestConnectionOptions>5__14; // 0x88
	            private ClientAppPauseStatus <lastConnectionPauseStatus>5__15; // 0x90
	            private int <lastSentSessionResumptionPingId>5__16; // 0x94
	            private int <lastReceivedSessionResumptionPongId>5__17; // 0x98
	            private MetaTime <lastSessionResumptionPingSentAt>5__18; // 0xA0
	            private int <lastIncidentReportedSessionResumptionPingId>5__19; // 0xA8
	            private int <numSessionResumptionPingIncidentsReported>5__20; // 0xAC
	            private Nullable<bool>[] <networkProbeResultBox>5__21; // 0xB0
	            private CancellationTokenSource <networkProbeCts>5__22; // 0xB8
	            private Task<ServerConnection> <connectTask>5__23; // 0xC0
	            private bool <loggedIn>5__24; // 0xC8
	            private bool <isConnected>5__25; // 0xC9
	            private MetaTime <connectOrReconnectStartedAt>5__26; // 0xD0
	            private Nullable<MetaTime> <sessionInitRequestTimeoutAt>5__27; // 0xD8
	            private MessageTransport.Error <connectionError>5__28; // 0xE8
	            private SessionProtocol.SessionStartAbortReasonTrailer <reasonTrailer>5__29; // 0xF0
	            private Task <closeTask>5__30; // 0xF8
	            private IHasNetworkDiagnosticReport <report>5__31; // 0x100 */

            var messageBuffer = new List<MetaMessage>();
            var delayedLoginMessageBuffer = new List<MetaMessage>();
            var qosMonitor = new TransportQosMonitor();

            Task<NetworkDiagnosticReport> networkDiagnosticReportTask = null;
            Task<ServerStatusHint> serverStatusHintFetchTask = null;
            var numConnectAttempts = 0;
            MetaTime latestMessagesTimestamp = default;

            var configResourceLoader = new ConfigResourceLoader(ct);
            var sessionResourceLoaders = new List<SessionResourceLoader>();

            ScheduledMaintenanceMode latestConnectionScheduledMaintenanceMode = null;
            Handshake.ConnectionOptions latestConnectionOptions = default;
            var lastConnectionPauseStatus = ClientAppPauseStatus.Running;
            var lastSentSessionResumptionPingId = 0;
            var lastReceivedSessionResumptionPongId = 0;

            var lastSessionResumptionPingSentAt = MetaTime.Epoch;
            var lastIncidentReportedSessionResumptionPingId = 0;
            var numSessionResumptionPingIncidentsReported = 0;
            SessionToken sessionToken = default;
            SessionProtocol.SessionStartAbortReasonTrailer reasonTrailer = null;

            _statistics = default;

            State = new Connecting(0);

            // Setup session information
            _sessionConnectionNdx = 0;
            _sessionNonce = BitConverter.ToUInt32(Guid.NewGuid().ToByteArray());

            // Setup resource loaders
            sessionResourceLoaders.Add(new LocalizationResourceLoader(ct));
            sessionResourceLoaders.Add(configResourceLoader);

            // Setup network probe
            var networkProbeResultBox = new bool?[1];
            CancellationTokenSource networkProbeCts = null;
            if (Endpoint.IsOfflineMode)
            {
                networkProbeResultBox[0] = true;
            }
            else
            {
                networkProbeCts = new CancellationTokenSource();
                RunNetworkProbeAsync(Endpoint.CdnBaseUrl, networkProbeCts.Token, networkProbeResultBox);
            }

            ConnectionState sessionStartError = null;
            ConnectionState cannotConnectError = null;

            // Z363
            if (!_credentialsPendingIOError)
            {
                MetaTime connectOrReconnectStartedAt;

                do
                {
                    // Reset resource loaders
                    foreach (var loader in sessionResourceLoaders)
                        loader.Reset();

                    // Create connection
                    lastConnectionPauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);

                    var connectTask = CreateConnection(GetResourceProposal(configResourceLoader.NegotiationResources), lastConnectionPauseStatus);
                    connectTask.Wait(ct);

                    if (ct.IsCancellationRequested)
                        if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                            yield break;

                    _serverConnection = connectTask.Result;

                    networkDiagnosticReportTask = null;

                    qosMonitor.Reset();
                    delayedLoginMessageBuffer.Clear();

                    MetaplaySDK.MessageDispatcher.SetConnection(this);

                    var loggedIn = false;
                    var isConnected = false;
                    connectOrReconnectStartedAt = MetaTime.Now;
                    MetaTime? sessionInitRequestTimeoutAt = null;

                ReceiveMessages:
                    var receiveMessageError = _serverConnection.ReceiveMessages(messageBuffer);
                    qosMonitor.ProcessMessages(messageBuffer, _serverConnection.IsLoggedIn);

                    foreach (var msg in messageBuffer)
                    {
                        if (msg is ConnectedToServer conn)
                        {
                            // Z868
                            if (!Endpoint.IsOfflineMode)
                            {
                                var cdnAddress = MetaplayCdnAddress.Create(Endpoint.CdnBaseUrl, conn.IsIPv4);
                                _sdkHook.OnCurrentCdnAddressUpdated(cdnAddress);
                            }
                            else
                            {
                                var cdnAddress = MetaplayCdnAddress.Empty;
                                _sdkHook.OnCurrentCdnAddressUpdated(cdnAddress);
                            }

                            var primaryUrl = MetaplaySDK.CdnAddress.PrimaryBaseUrl;
                            var backupGateways = Endpoint.BackupGateways.ToList();

                            Endpoint = new ServerEndpoint(Endpoint.ServerHost, Endpoint.ServerPort, Endpoint.EnableTls, primaryUrl, backupGateways);

                            latestMessagesTimestamp = MetaTime.Now;
                            _statistics.CurrentConnection.HasCompletedHandshake = true;
                            isConnected = true;

                            sessionInitRequestTimeoutAt = MetaTime.Now + Config.ServerSessionInitTimeout;

                            Delegate.OnHandshakeComplete();
                        }
                        else if (msg is SessionProtocol.SessionStartSuccess suc)
                        {
                            loggedIn = true;
                            latestConnectionScheduledMaintenanceMode = suc.ScheduledMaintenanceMode;
                            sessionInitRequestTimeoutAt = null;
                            sessionToken = suc.SessionToken;

                            foreach (var loader in sessionResourceLoaders)
                            {
                                var error = loader.TrySpecialize(suc);
                                if (error == null)
                                    continue;

                                sessionStartError = error;
                                break;
                            }

                            if (sessionStartError != null)
                            {
                                if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                    if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                        yield break;
                            }

                            ServerOptions = suc.ServerOptions;

                            _sdkHook.OnSessionStarted(suc);
                            Delegate.OnSessionStarted(SessionStartResources);
                        }
                        else if (msg is UpdateScheduledMaintenanceMode maintenance)
                        {
                            latestConnectionScheduledMaintenanceMode = maintenance.ScheduledMaintenanceMode;
                            var state = ScheduledMaintenanceModeToMaintenanceModeState(latestConnectionScheduledMaintenanceMode);

                            _sdkHook.OnScheduledMaintenanceModeUpdated(state);
                        }
                        else if (msg is Handshake.LoginResponse loginRes)
                        {
                            latestConnectionOptions = loginRes.Options;
                        }
                        else if (msg is MessageTransportInfoWrapperMessage infoWrap)
                        {
                            if (infoWrap.Info is ServerConnection.GotServerHello hello)
                            {
                                LatestServerVersion = hello.ServerHello.ServerVersion;
                            }
                            else if (infoWrap.Info is ServerConnection.LoginCredentialsChangedInfo credChanged)
                            {
                                var handled = HandleCredentialsChanged(credChanged);
                                if (!handled)
                                {
                                    // Log debug "Failure while writing credentials to disk."

                                    sessionStartError = new TerminalError.NoFreeDiskSpace();

                                    if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                        if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                            yield break;
                                }
                            }
                            else if (infoWrap.Info is ServerConnection.ResourceCorrectionInfo rci)
                            {
                                sessionInitRequestTimeoutAt = null;

                                foreach (var loader in sessionResourceLoaders)
                                    loader.SetupFromResourceCorrection(rci.ResourceCorrection);
                            }
                            else if (infoWrap.Info is ServerConnection.FullProtocolHashMismatchInfo hashMismatch)
                            {
                                Delegate.OnFullProtocolHashMismatch(hashMismatch.ClientProtocolHash, hashMismatch.ServerProtocolHash);
                            }
                        }
                        else if (msg is Handshake.OperationStillOngoing)
                        {
                            sessionInitRequestTimeoutAt = MetaTime.Now + Config.ServerSessionInitTimeout;
                        }
                    }

                    if (messageBuffer.Count > 0)
                        latestMessagesTimestamp = MetaTime.Now;

                    delayedLoginMessageBuffer.AddRange(messageBuffer);
                    messageBuffer.Clear();

                    _statistics.CurrentConnection.NetworkProbeStatus = networkProbeResultBox[0];
                    if (receiveMessageError == null)
                    {
                        if (sessionInitRequestTimeoutAt.HasValue)
                        {
                            if (MetaTime.Now >= sessionInitRequestTimeoutAt.Value)
                            {
                                // Log debug "Timeout while waiting for session init response from server."

                                sessionStartError = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.Stream);

                                if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                    if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                        yield break;
                            }
                        }

                        // Z1130
                        bool bVar4 = false;
                        bool bVar23 = true;
                        foreach (var loader in sessionResourceLoaders)
                        {
                            // Z1913
                            if (loader.IsComplete)
                                continue;

                            // Z1922
                            if (!loader.PollDownload(out var pollError))
                            {
                                bVar23 = false;
                                continue;
                            }

                            // Z1709
                            if (pollError != null)
                            {
                                // Z1928
                                if (CloseSupervisionLoop(pollError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                    if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                        yield break;
                            }

                            var activateError = loader.TryActivate();
                            if (activateError != null)
                            {
                                // Z1928
                                if (CloseSupervisionLoop(activateError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                    if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                        yield break;
                            }

                            bVar4 = true;
                        }

                        // Z1721
                        if (bVar23 && bVar4)
                        {
                            // Z1727
                            lastConnectionPauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);

                            _serverConnection.RetrySessionStart(GetResourceProposal(configResourceLoader.NegotiationResources), lastConnectionPauseStatus);

                            sessionInitRequestTimeoutAt = MetaTime.Now + Config.ServerSessionInitTimeout;
                        }

                        // Z1771
                        if (!loggedIn)
                        {
                            if (!isConnected && serverStatusHintFetchTask == null)
                            {
                                // Z1773
                                if (MetaTime.Now >= connectOrReconnectStartedAt + Config.ServerStatusHintCheckDelay)
                                    serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);
                            }

                            // Z1789
                            if (serverStatusHintFetchTask != null)
                            {
                                serverStatusHintFetchTask.Wait(ct);

                                if (ct.IsCancellationRequested)
                                    if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                        if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                            yield break;

                                if (serverStatusHintFetchTask.Result.MaintenanceMode != null)
                                {
                                    var start = serverStatusHintFetchTask.Result.MaintenanceMode.GetStartAtMetaTime();
                                    var estimated = serverStatusHintFetchTask.Result.MaintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                                    var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                                    _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                                    State = new TerminalError.InMaintenance();

                                    if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                        yield break;
                                }
                            }

                            goto ReceiveMessages;
                        }

                        // Z1803
                        _statistics.CurrentConnection.HasCompletedSessionInit = true;

                        State = new Connected(qosMonitor.IsHealthy, latestMessagesTimestamp);

                        var pauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);
                        if (lastConnectionPauseStatus != pauseStatus)
                        {
                            // Z1827
                            switch (MetaplaySDK.ApplicationPauseStatus)
                            {
                                case ApplicationPauseStatus.Running:
                                case ApplicationPauseStatus.ResumedFromPauseThisFrame:
                                    _serverConnection.EnqueueSendMessage(new ClientLifecycleHintUnpaused());
                                    break;

                                case ApplicationPauseStatus.Pausing:
                                    _serverConnection.EnqueueSendMessage(new ClientLifecycleHintPausing(MetaplaySDK.ApplicationPauseDeclaredMaxDuration, MetaplaySDK.ApplicationPauseReason));
                                    break;
                            }
                        }

                        // Z1879
                        _messagesToDispatch.AddRange(delayedLoginMessageBuffer);
                        delayedLoginMessageBuffer.Clear();

                        var maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(latestConnectionScheduledMaintenanceMode);
                        _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);

                    // Z2231
                    ReceiveMessages2:
                        var connectionError = _serverConnection.ReceiveMessages(messageBuffer);
                        qosMonitor.ProcessMessages(messageBuffer, _serverConnection.IsLoggedIn);

                        // Z2250
                        var msgCount = messageBuffer.Count;
                        foreach (var msg in messageBuffer)
                        {
                            if (msg == null)
                                continue;

                            if (msg is SessionProtocol.SessionResumeSuccess suc)
                            {
                                // Z2335
                                latestConnectionScheduledMaintenanceMode = suc.ScheduledMaintenanceMode;
                                maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(suc.ScheduledMaintenanceMode);

                                _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);

                                lastSentSessionResumptionPingId++;
                                _serverConnection.EnqueueSendMessage(new SessionPing(lastSentSessionResumptionPingId));

                                lastSessionResumptionPingSentAt = MetaTime.Now;
                            }
                            else if (msg is SessionPong pong)
                            {
                                lastReceivedSessionResumptionPongId = pong.Id;
                            }
                            else if (msg is UpdateScheduledMaintenanceMode modeMsg)
                            {
                                latestConnectionScheduledMaintenanceMode = modeMsg.ScheduledMaintenanceMode;

                                maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(modeMsg.ScheduledMaintenanceMode);
                                _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);
                            }
                            else if (msg is Handshake.LoginResponse loginRes)
                            {
                                latestConnectionOptions = loginRes.Options;
                            }
                        }

                        // Z2397
                        _messagesToDispatch.AddRange(messageBuffer);
                        messageBuffer.Clear();

                        // Z2417
                        _statistics.CurrentConnection.NetworkProbeStatus = networkProbeResultBox[0];

                        // Z2421
                        if (msgCount > 0)
                            latestMessagesTimestamp = MetaTime.Now;

                        if (connectionError == null)
                        {
                            // Z2429
                            if (ShouldEndSessionDueToRecentPause)
                            {
                                // Log debug "A long duration in background just ended, will end session"
                                State = new TransientError.SessionLostInBackground();

                                _messagesToDispatch.Add(new DisconnectedFromServer());
                            }
                            else
                            {
                                // Z2431
                                if (msgCount < 1 && bVar4)
                                    State = new Connected(lastSentSessionResumptionPingId == lastReceivedSessionResumptionPongId && qosMonitor.IsHealthy, latestMessagesTimestamp);

                                var unpauseTime = MetaplaySDK.ApplicationLastPauseBeganAt + MetaplaySDK.ApplicationLastPauseDuration;
                                if (lastSentSessionResumptionPingId != lastReceivedSessionResumptionPongId && lastSentSessionResumptionPingId != lastIncidentReportedSessionResumptionPingId)
                                {
                                    if (numSessionResumptionPingIncidentsReported < Config.MaxSessionPingPongDurationIncidentsPerSession)
                                    {
                                        if (MetaplaySDK.ApplicationPauseStatus == ApplicationPauseStatus.Running)
                                        {
                                            if (MetaTime.Now > unpauseTime + MetaDuration.FromSeconds(5))
                                            {
                                                var lastPingTime = MetaTime.Now - lastSessionResumptionPingSentAt;
                                                var connectedDuration = MetaDuration.FromTimeSpan(_serverConnection._statistics.DurationToConnected);
                                                var pingThreshold = connectedDuration + Config.SessionPingPongDurationIncidentThreshold;

                                                if (lastPingTime > pingThreshold)
                                                {
                                                    var loginDiag = Delegate.GetLoginDebugDiagnostics(true);
                                                    MetaplaySDK.IncidentTracker.ReportSessionPingPongDurationThresholdExceeded(loginDiag, connectedDuration, _serverConnection._currentGateway, sessionToken, lastSentSessionResumptionPingId, lastPingTime);

                                                    lastIncidentReportedSessionResumptionPingId = lastSentSessionResumptionPingId;
                                                    numSessionResumptionPingIncidentsReported++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            yield return Marker.HandleMessagesAndCallAgain;

                            // Z1353 (case 3 to case 4)
                            if (ct.IsCancellationRequested)
                            {
                                if (State.Status == ConnectionStatus.Connected)
                                {
                                    if (_flushEnqueuedMessagesBeforeClose)
                                    {
                                        // Log info "signaled connection to close, waiting"
                                        Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                                    }
                                }
                            }
                            else
                            {
                                if (connectionError == null)
                                {
                                    if (!ShouldEndSessionDueToRecentPause)
                                    {
                                        if (!ct.IsCancellationRequested)
                                            goto ReceiveMessages2;

                                        if (_flushEnqueuedMessagesBeforeClose)
                                        {
                                            // Log info "signaled connection to close, waiting"
                                            Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                                        }
                                    }
                                }
                            }

                            if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                    yield break;
                        }

                        // Z2595
                        var connectionState = TranslateError(connectionError);
                        // Log debug "Failure during session. {connectionError}, causes {connectionState}"

                        // Z2627
                        if (!(connectionState is TerminalError.InMaintenance))
                        {
                            State = TranslateConnectionErrorForUser(connectionState);
                            yield return Marker.HandleMessagesAndCallAgain;

                            // Z1353 (case 3 to case 4)
                            if (ct.IsCancellationRequested)
                            {
                                if (State.Status == ConnectionStatus.Connected)
                                {
                                    if (_flushEnqueuedMessagesBeforeClose)
                                    {
                                        // Log info "signaled connection to close, waiting"
                                        Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                                    }
                                }
                            }
                            else
                            {
                                if (connectionError == null)
                                {
                                    if (!ShouldEndSessionDueToRecentPause)
                                    {
                                        if (!ct.IsCancellationRequested)
                                            goto ReceiveMessages2;

                                        if (_flushEnqueuedMessagesBeforeClose)
                                        {
                                            // Log info "signaled connection to close, waiting"
                                            Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                                        }
                                    }
                                }
                            }

                            if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                    yield break;
                        }

                        // Z2640
                        if (latestConnectionScheduledMaintenanceMode == null)
                        {
                            var ongoing = MaintenanceModeState.CreateOngoing(MetaTime.Now, null);
                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                        }
                        else
                        {
                            MetaTime? estimated = null;
                            if (latestConnectionScheduledMaintenanceMode.EstimationIsValid)
                                estimated = latestConnectionScheduledMaintenanceMode.StartAt + MetaDuration.FromMinutes(latestConnectionScheduledMaintenanceMode.EstimatedDurationInMinutes);

                            var ongoing = MaintenanceModeState.CreateOngoing(latestConnectionScheduledMaintenanceMode.StartAt, estimated);
                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                        }

                        // Z2726
                        State = new TerminalError.InMaintenance();

                        if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                            if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                yield break;
                    }

                    // Z1143
                    if (receiveMessageError is ServerConnection.RedirectToServerError redError)
                    {
                        // Z1150
                        // Log info "Redirecting to server: {redError.RedirectToServer}"
                        Endpoint = redError.RedirectToServer;
                        continue;
                    }

                    // Z1164
                    var translatedState = TranslateError(receiveMessageError);
                    // Log debug "Failure while connecting. {receiveMessageError}, causes {translatedState}"

                    if (translatedState == null)
                    {
                        // Z1191
                        cannotConnectError = TranslateConnectionErrorForUser(translatedState);

                        if (SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                            if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                yield break;
                    }

                    // Z1196
                    if (translatedState is TransientError te)
                    {
                        // Z1220
                        networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
                        serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);

                        numConnectAttempts++;
                        if (Config.ConnectAttemptsMaxCount <= numConnectAttempts)
                        {
                            // Z1237
                            serverStatusHintFetchTask?.Wait(ct);

                            cannotConnectError = TranslateConnectionErrorForUser(translatedState);

                            if (SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                    yield break;
                        }

                        // Z1242
                        var connectingState = new Connecting(numConnectAttempts);

                        State = connectingState;

                        _serverConnection?.Dispose();
                        _serverConnection = null;

                        serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);

                        connectOrReconnectStartedAt = MetaTime.Now + Config.ConnectAttemptInterval;
                        // Log info "Reconnecting in {Config.ConnectAttemptInterval} (try {numConnectAttempts} out of {Config.ConnectAttemptsMaxCount})..."

                        if (serverStatusHintFetchTask.Result.MaintenanceMode != null)
                        {
                            var start = serverStatusHintFetchTask.Result.MaintenanceMode.GetStartAtMetaTime();
                            var estimated = serverStatusHintFetchTask.Result.MaintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                            var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                            State = new TerminalError.InMaintenance();
                        }

                        State = cannotConnectError;

                        if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                            yield break;
                    }
                    else if (translatedState is TerminalError.InMaintenance)
                    {
                        // Z1210
                        serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);
                        serverStatusHintFetchTask.Wait(ct);

                        // Z1217
                        if (ct.IsCancellationRequested)
                            if (CloseSupervisionLoop(sessionStartError, latestConnectionOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                                if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                    yield break;

                        if (serverStatusHintFetchTask.Result.MaintenanceMode != null)
                        {
                            var start = serverStatusHintFetchTask.Result.MaintenanceMode.GetStartAtMetaTime();
                            var estimated = serverStatusHintFetchTask.Result.MaintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                            var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                            State = new TerminalError.InMaintenance();
                        }

                        State = cannotConnectError;

                        if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                            yield break;
                    }
                    else
                    {
                        // Z1191
                        cannotConnectError = TranslateConnectionErrorForUser(translatedState);

                        if (SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                            if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                                yield break;
                    }
                } while (MetaTime.Now >= connectOrReconnectStartedAt);
            }

            // Z1313
            // Log debug "Failure while updating credentials to disk."

            sessionStartError = new TerminalError.NoFreeDiskSpace();

            if (SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                if (TerminateConnection(sessionResourceLoaders, networkProbeCts))
                    yield break;
        }

        // CUSTOM: Closes the supervision loop connections
        private bool CloseSupervisionLoop(ConnectionState sessionStartError, Handshake.ConnectionOptions latestConnectionOptions, CancellationToken ct, ref Task<ServerStatusHint> serverStatusHintFetchTask, ref Task<NetworkDiagnosticReport> networkDiagnosticReportTask)
        {
            // SupervisionLoop Z1936

            // Log info "Client failed to start session. Sending failure report to server when network diagnostics complete."

            if (serverStatusHintFetchTask == null && sessionStartError != null)
                if (sessionStartError is TransientError)
                    serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);

            networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
            networkDiagnosticReportTask.Wait(ct);

            if (!ct.IsCancellationRequested)
            {
                SessionProtocol.SessionStartAbortReasonTrailer reasonTrailer = null;

                var failedReport = MetaplaySDK.IncidentTracker.TryCreateSessionStartFailureReport(sessionStartError, Endpoint, LatestTlsPeerDescription, networkDiagnosticReportTask.Result, false);
                if (failedReport == null)
                {
                    // Log debug "Session start incident report throttled. Will not send the report."
                }
                else
                {
                    var suffix = (uint)PlayerIncidentUtil.GetSuffixFromIncidentId(failedReport.ErrorType);
                    var coinFlip = KeyedStableWeightedCoinflip.FlipACoin(0x1247a312, suffix, latestConnectionOptions.PushUploadPercentageSessionStartFailedIncidentReport * 10);
                    if (!coinFlip)
                    {
                        // Log debug "Session start incident report throttled due to server-side limit. Will not send the report."
                    }
                    else
                    {
                        var delivery = PlayerIncidentUtil.TryCompressIncidentForNetworkDelivery(failedReport);
                        if (delivery != null)
                            reasonTrailer = new SessionProtocol.SessionStartAbortReasonTrailer(failedReport.ErrorType, delivery);
                    }
                }

                var aborted = _serverConnection.AbortSessionStart(reasonTrailer);
                if (!aborted)
                {
                    // Log debug "Transport was lost before session start incident report could be sent."
                }
                else
                {
                    var closeTask = _serverConnection.EnqueueCloseAsync();
                    var connectOrReconnectStartedAt = MetaTime.Now + Config.CloseFlushTimeout;

                    closeTask.Wait(ct);

                    if (MetaTime.Now <= connectOrReconnectStartedAt)
                    {
                        if (ct.IsCancellationRequested)
                            goto CloseFinal;
                    }

                    // Log debug reasonTrailer != null ? "Session start incident report sent." : "Session start abort request sent."
                }

                _sdkHook.SuppressIncidentReportForNextNetworkError();

                var cannotConnectError = sessionStartError;

                if (SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask))
                    goto CloseFinal;
            }

        CloseFinal:
            return true;
        }

        // CUSTOM: 
        private bool SendReport(ConnectionState sessionStartError, ConnectionState cannotConnectError, CancellationToken ct, ref Task<ServerStatusHint> serverStatusHintFetchTask, ref Task<NetworkDiagnosticReport> networkDiagnosticReportTask)
        {
            if (serverStatusHintFetchTask == null && sessionStartError != null)
                if (sessionStartError is TransientError)
                    serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);

            // Z2108
            var report = (IHasNetworkDiagnosticReport)sessionStartError;
            if (report != null)
            {
                // Z2106
                networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
                networkDiagnosticReportTask.Wait(ct);

                if (ct.IsCancellationRequested)
                    goto CloseFinal;

                report.NetworkDiagnosticReport = networkDiagnosticReportTask.Result;
            }

            // Z2152
            if (serverStatusHintFetchTask != null && cannotConnectError != null)
            {
                if (cannotConnectError is TransientError)
                {
                    // Z1473
                    serverStatusHintFetchTask.Wait(ct);
                    if (ct.IsCancellationRequested)
                        // LAB_01cbcf34
                        goto CloseFinal;

                    // Z1497
                    var start = serverStatusHintFetchTask.Result.MaintenanceMode.GetStartAtMetaTime();
                    var estimated = serverStatusHintFetchTask.Result.MaintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                    var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                    _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                    State = new TerminalError.InMaintenance();

                    goto CloseFinal;
                }
            }

            State = cannotConnectError;

        CloseFinal:
            return true;
        }

        // CUSTOM: Terminates connection instances in SupervisionLoop
        private bool TerminateConnection(List<SessionResourceLoader> sessionResourceLoaders, CancellationTokenSource networkProbeCts)
        {
            // Log info "Connection terminated"

            _serverConnection?.Dispose();
            _serverConnection = null;

            foreach (var loader in sessionResourceLoaders)
                loader.Reset();

            MetaplaySDK.MessageDispatcher.SetConnection(null);

            networkProbeCts?.Cancel();

            return true;
        }

        private ConnectionState TranslateConnectionErrorForUser(ConnectionState defaultResult)
        {
            if (defaultResult == null)
                return null;

            if (defaultResult is TransientError.Closed || defaultResult is TransientError.TlsError ||
                defaultResult is TransientError.Timeout || defaultResult is TransientError.FailedToResumeSession)
            {
                // Log debug "A long duration in background just ended, will mask error"

                var networkStatus = _statistics.CurrentConnection.NetworkProbeStatus.GetValueOrDefault();
                if (_statistics.CurrentConnection.NetworkProbeStatus.HasValue && !networkStatus && _statistics.CurrentConnection.HasCompletedHandshake)
                    return new TerminalError.NoNetworkConnectivity();
            }

            return defaultResult;
        }

        private ConnectionState TranslateError(MessageTransport.Error error)
        {
            if (error == null)
                return new TerminalError.Unknown(null);

            if (error is WireMessageTransport.InvalidGameMagic igm)
                return new TerminalError.InvalidGameMagic(igm.Magic);

            if (error is WireMessageTransport.WireProtocolVersionMismatch vm)
                return new TerminalError.WireProtocolVersionMismatch(3, vm.ServerProtocolVersion);

            if (error is WireMessageTransport.ProtocolStatusError statusError)
            {
                switch (statusError.status)
                {
                    case ProtocolStatus.InMaintenance:
                        return new TerminalError.InMaintenance();

                    case ProtocolStatus.ClusterShuttingDown:
                        return new TransientError.ClusterNotReady(TransientError.ClusterNotReady.ClusterStatus.ClusterShuttingDown);

                    case ProtocolStatus.ClusterStarting:
                        return new TransientError.ClusterNotReady(TransientError.ClusterNotReady.ClusterStatus.ClusterStarting);

                    default:
                        return new TerminalError.Unknown(statusError.status.ToString());
                }
            }

            if (error is ServerConnection.SessionForceTerminatedError term)
            {
                if (term.Reason == null)
                    return new TransientError.SessionForceTerminated(term.Reason);

                if (term.Reason is SessionForceTerminateReason.MaintenanceModeStarted)
                    return new TerminalError.InMaintenance();

                if (term.Reason is SessionForceTerminateReason.PauseDeadlineExceeded)
                    return new TransientError.Closed();
            }

            if (error is ServerConnection.MaintenanceModeOngoingError ongoing)
                return new TerminalError.InMaintenance();

            if (error is WireMessageTransport.WireFormatError formatErr)
                return new TerminalError.WireFormatError(formatErr.DecodeException);

            if (error is MessageTransport.EnqueuedCloseError || error is TcpMessageTransport.CouldNotConnectError ||
                error is TcpMessageTransport.ConnectionRefused || error is WebSocketTransport.CouldNotConnectError ||
                error is WebSocketTransport.WebSocketError || error is WebSocketTransport.WebSocketClosedError ||
                error is StreamMessageTransport.StreamClosedError || error is StreamMessageTransport.StreamIOFailedError ||
                error is StreamMessageTransport.StreamExecutorError)
                return new TransientError.Closed();

            if (error is WireMessageTransport.ConnectTimeoutError)
                return new TransientError.Timeout(TransientError.Timeout.TimeoutSource.Connect);

            if (error is WireMessageTransport.TimeoutError)
                return new TransientError.Timeout(TransientError.Timeout.TimeoutSource.Stream);

            if (error is ServerConnection.UnexpectedLoginMessageError login)
                return new TransientError.ProtocolError(TransientError.ProtocolError.ErrorKind.UnexpectedLoginMessage, "unexpected login message: " + login.MessageType);

            if (error is WireMessageTransport.MissingHelloError)
                return new TransientError.ProtocolError(TransientError.ProtocolError.ErrorKind.MissingServerHello, "missing server hello");

            if (error is ServerConnection.LogicVersionMismatchError versionMismatch)
                return new TerminalError.LogicVersionMismatch(versionMismatch.ClientSupportedVersions, versionMismatch.ServerAcceptedVersions);

            if (error is ServerConnection.CommitIdMismatchMismatchError commitMismatch)
                return new TerminalError.CommitIdMismatch(commitMismatch.ClientCommitId, commitMismatch.ServerCommitId);

            if (error is TlsMessageTransport.TlsError tlsError)
            {
                switch (tlsError.Error)
                {
                    case TlsMessageTransport.TlsError.ErrorCode.NotEncrypted:
                        return new TransientError.TlsError(TransientError.TlsError.ErrorCode.NotEncrypted);

                    case TlsMessageTransport.TlsError.ErrorCode.FailureWhileAuthenticating:
                        return new TransientError.TlsError(TransientError.TlsError.ErrorCode.FailureWhileAuthenticating);

                    case TlsMessageTransport.TlsError.ErrorCode.NotAuthenticated:
                        return new TransientError.TlsError(TransientError.TlsError.ErrorCode.NotAuthenticated);

                    default:
                        return new TransientError.TlsError(TransientError.TlsError.ErrorCode.Unknown);
                }
            }

            if (error is ServerConnection.SessionResumeFailed)
                return new TransientError.FailedToResumeSession();

            if (error is ServerConnection.SessionStartFailed startFailed)
                return new TransientError.ProtocolError(TransientError.ProtocolError.ErrorKind.SessionStartFailed, startFailed.Message);

            if (error is ServerConnection.SessionError sessionError)
                return new TransientError.ProtocolError(TransientError.ProtocolError.ErrorKind.SessionProtocolError, "session protocol violation: " + sessionError.Reason);

            if (error is ServerConnection.PlayerIsBannedError)
                return new TerminalError.PlayerIsBanned();

            if (error is ServerConnection.UsingWrongAuthenticationMethodError)
                return new TerminalError.WrongAuthenticationMethod();

            if (error is ServerConnection.SocialAuthenticationLoginFailedError)
                return new TerminalError.SocialAuthenticationLoginFailed();

            if (error is ServerConnection.PlayerDeserializationFailureError desError)
                return new TerminalError.ServerPlayerDeserializationFailure(desError.Error);

            if (error is ServerConnection.WatchdogDeadlineExceededError watchError)
            {
                var retErr = new TransientError.InternalWatchdogDeadlineExceeded(watchError.WatchdogType);
                MetaplaySDK.IncidentTracker.ReportWatchdogDeadlineExceededError();

                return retErr;
            }

            return new TerminalError.Unknown(null);
        }

        private MaintenanceModeState ScheduledMaintenanceModeToMaintenanceModeState(ScheduledMaintenanceMode scheduledMaintenanceMaybe)
        {
            if (scheduledMaintenanceMaybe == null)
                return MaintenanceModeState.CreateNotScheduled();

            if (!scheduledMaintenanceMaybe.EstimationIsValid)
                return MaintenanceModeState.CreateUpcoming(scheduledMaintenanceMaybe.StartAt, null);

            var estimatedDuration = MetaDuration.FromMinutes(scheduledMaintenanceMaybe.EstimatedDurationInMinutes);
            var estimatedEnd = scheduledMaintenanceMaybe.StartAt + estimatedDuration;

            return MaintenanceModeState.CreateUpcoming(scheduledMaintenanceMaybe.StartAt, estimatedEnd);
        }

        private async Task<NetworkDiagnosticReport> GetNetworkDiagnosticReportAsync()
        {
            if (Endpoint.IsOfflineMode)
                return new NetworkDiagnosticReport();

            var ports = new List<int> { Endpoint.PrimaryGateway.ServerPort };
            ports = ports.Concat(Endpoint.BackupGateways.Select(x => x.ServerPort)).ToList();

            var primaryHost4 = MetaplayHostnameUtil.GetV4V6SpecificHost(Endpoint.PrimaryGateway.ServerHost, true);
            var primaryHost6 = MetaplayHostnameUtil.GetV4V6SpecificHost(Endpoint.PrimaryGateway.ServerHost, false);

            var host4 = new Uri(MetaplaySDK.CdnAddress.IPv4BaseUrl).Host;
            var host6 = new Uri(MetaplaySDK.CdnAddress.IPv6BaseUrl).Host;

            var report = NetworkDiagnostics.GenerateReport(primaryHost4, primaryHost6, ports, Endpoint.PrimaryGateway.EnableTls, host4, host6, TimeSpan.FromSeconds(5));
            await report.Item2;

            return report.Item1;
        }

        private static async Task<ServerStatusHint> GetServerStatusHintAsync(/*LogChannel log, */ServerEndpoint endpoint, ConnectionConfig config)
        {
            /*	public int <>1__state; // 0x0
	            public AsyncTaskMethodBuilder<MetaplayConnection.ServerStatusHint> <>t__builder; // 0x8
	            public LogChannel log; // 0x20
	            public ServerEndpoint endpoint; // 0x28
	            public ConnectionConfig config; // 0x30
	            private List.Enumerator<string> <>7__wrap1; // 0x38
	            private TaskAwaiter<MetaplayConnection.ServerStatusHint> <>u__1; // 0x50 */

            // Log debug "Server status check started"

            var urls = new List<string>();
            if (!endpoint.IsOfflineMode)
            {
                var volatileCdn = MetaplaySDK.CdnAddress.GetSubdirectoryAddress("Volatile");

                urls.Add(volatileCdn.PrimaryBaseUrl + "serverStatusHint.json");
                urls.Add(volatileCdn.SecondaryBaseUrl + "serverStatusHint.json");
            }

            foreach (var url in urls)
            {
                var hint = await TryGetServerStatusHintFromSourceAsync(url, config);
                if (hint != null)
                    return hint;
            }

            // Log debug "Server status check failed. All sources failed."
            return ServerStatusHint.ForFetchFailure();
        }

        private static async Task<ServerStatusHint> TryGetServerStatusHintFromSourceAsync(/*LogChannel log,*/ string sourceUrl, ConnectionConfig config)
        {
            var responseTask = WebRequest.CreateHttp(sourceUrl).GetResponseAsync();
            var wait = Task.Delay((int)config.ServerStatusHintConnectTimeout.Milliseconds);

            await Task.WhenAny(responseTask, wait);

            if (responseTask.Status != TaskStatus.RanToCompletion)
            {
                if (responseTask.Status == TaskStatus.Faulted)
                {
                    // Log debug "Server status check source failed. Endpoint={sourceUrl}, Error={responseTask.Exception.Message}"
                }
                else
                {
                    // Log debug "Server status check source timed out. Endpoint={sourceUrl}"
                    responseTask.ContinueWithDispose();
                }

                return null;
            }

            await using var memoryStream = new MemoryStream();
            using var response = responseTask.Result;

            var readComplete = response.GetResponseStream().CopyToAsync(memoryStream);
            wait = Task.Delay((int)config.ServerStatusHintReadTimeout.Milliseconds);

            await Task.WhenAny(readComplete, wait);

            if (readComplete.Status != TaskStatus.RanToCompletion)
            {
                // Log debug "Server status check source read timed out. Endpoint={sourceUrl}"
                return null;
            }

            var hint = TryParseServerStatusHint(memoryStream.ToArray(), (int)memoryStream.Length);
            if (hint == null)
            {
                // Log debug "Server status check source supplied invalid data, ignored. Endpoint={sourceUrl}"
                return null;
            }

            // Log debug "Server status check complete. Endpoint={sourceUrl}"
            return hint;
        }

        private static ServerStatusHint TryParseServerStatusHint(byte[] buffer, int length)
        {
            var hintObj = JsonConvert.DeserializeObject<ServerStatusHintJsonRecord>(Encoding.UTF8.GetString(buffer, 0, length));
            return ServerStatusHint.TryParseFromRecord(hintObj);
        }

        private static async Task RunNetworkProbeAsync(/*LogChannel log,*/ string probeUrl, CancellationToken ct, bool?[] networkProbeResultBox)
        {
            /*	public int <>1__state; // 0x0
	            public AsyncTaskMethodBuilder <>t__builder; // 0x8
	            public CancellationToken ct; // 0x20
	            public LogChannel log; // 0x28
	            private MetaplayConnection.<>c__DisplayClass89_0 <>8__1; // 0x30
	            public string probeUrl; // 0x38
	            public Nullable<bool>[] networkProbeResultBox; // 0x40
	            private int <attemptNdx>5__2; // 0x48
	            private Stopwatch <sw>5__3; // 0x50
	            private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<WebResponse> <>u__1; // 0x58
	            private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter <>u__2; // 0x68 */

            var attemptNdx = 0;

            HttpWebRequest networkProbe = null;
            ct.Register(() => networkProbe?.Abort());

            // Log debug "Testing network reachability with a network probe."

            var sw = Stopwatch.StartNew();

            networkProbe = WebRequest.CreateHttp(probeUrl);
            networkProbe.Method = "HEAD";

            // Log debug "Sending network probe {attemptNdx + 1}"

            using var response = await networkProbe.GetResponseAsync();
            networkProbeResultBox[0] = false;

            // Log debug "Network probe {attemptNdx + 1} completed successfully (took {sw.ElapsedMilliseconds}ms)."
        }

        private bool HandleCredentialsChanged(ServerConnection.LoginCredentialsChangedInfo credentialUpdate)
        {
            if (credentialUpdate.Change == ServerConnection.LoginCredentialsChangedInfo.ChangeType.PlayerIdChanged)
                ; // Log info "Server updated our PlayerId on login success: old={_credentials.PlayerId.ToString()}, new={credentialUpdate.PlayerId.ToString()}"

            var devCreds = new DeviceCredentials
            {
                DeviceId = credentialUpdate.DeviceId,
                AuthToken = credentialUpdate.AuthToken,
                PlayerId = credentialUpdate.PlayerId
            };

            if (!Endpoint.IsOfflineMode)
                return SaveCredentials(devCreds);

            return true;
        }

        private bool SaveCredentials(DeviceCredentials credentials)
        {
            // Log info "Saving credentials: deviceId={credentials.DeviceId}, playerId={credentials.PlayerId.ToString()}"

            _credentials = credentials;

            // This method got inlined in the original code, but it does exactly the same
            return CredentialsStore.StoreCredentials(credentials);
        }

        private static ClientAppPauseStatus ToClientAppPauseStatus(ApplicationPauseStatus status)
        {
            return (ClientAppPauseStatus)status;
        }

        private SessionProtocol.SessionResourceProposal GetResourceProposal(ClientSessionNegotiationResources negotiationState)
        {
            var activeLang = MetaplaySDK.LocalizationManager.ActiveLocalizationLanguage;
            return negotiationState.ToResourceProposal(activeLang, MetaplaySDK.LocalizationManager.ActiveLocalizationVersion);
        }

        private async Task<ConfigArchive> DownloadConfigArchiveAsync(string name, ContentHash version, string nullableUriSuffix, CancellationToken ct)
        {
            ConfigArchive configArchive;

            if (Endpoint.IsOfflineMode)
            {
                configArchive = OfflineServer.GameConfigArchive;
                if (version != configArchive.Version)
                    throw new InvalidOperationException($"Attempted to use offline server with invalid config version ({version}): can only use current {configArchive.Version}");
            }
            else
            {
                var configDir = Path.Combine(Application.PersistentDataPath, "GameConfigCache");
                var storage = new DiskBlobStorage(configDir);
                var storageProvider = new StorageBlobProvider(storage);

                var data = await storageProvider.GetAsync(name, version);
                if (data == null)
                {
                    var subAddr = MetaplaySDK.CdnAddress.GetSubdirectoryAddress("GameConfig");
                    var httpProvider = new HttpBlobProvider(new MetaHttpClient(), subAddr, nullableUriSuffix);
                    var cacheProvider = new CachingBlobProvider(httpProvider, storageProvider);
                    var archiveProvider = new BlobConfigArchiveProvider(cacheProvider, name);

                    configArchive = await DownloadConfigWithRetriesAsync(() => archiveProvider.GetAsync(version), ct);
                }
                else
                    configArchive = ConfigArchive.FromBytes(data);
            }

            return configArchive;
        }

        private async Task<GameConfigSpecializationPatches> DownloadConfigPatchesAsync(ContentHash version, CancellationToken ct)
        {
            if (version == ContentHash.None)
                return null;

            if (Endpoint.IsOfflineMode)
                throw new InvalidOperationException("offline mode does not support patching");

            var subAddress = MetaplaySDK.CdnAddress.GetSubdirectoryAddress("GameConfig");
            var httpProvider = new HttpBlobProvider(MetaHttpClient.DefaultInstance, subAddress, null);

            var path = Path.Combine(Application.PersistentDataPath, "GameConfigCache");
            var diskStorage = new DiskBlobStorage(path);
            var storageProvider = new StorageBlobProvider(diskStorage);

            var cacheProvider = new CachingBlobProvider(httpProvider, storageProvider);
            return await DownloadConfigWithRetriesAsync(async () =>
                GameConfigSpecializationPatches.FromBytes(await cacheProvider.GetAsync("SharedGameConfigPatches", version)), ct);
        }

        private async Task<TResult> DownloadConfigWithRetriesAsync<TResult>(Func<Task<TResult>> taskFactory, CancellationToken ct)
        {
            while (true)
            {
                if (ct.IsCancellationRequested)
                    break;

                var getDataResult = await taskFactory.Invoke();
                if (getDataResult != null)
                    return getDataResult;

                await Task.Delay(1000, ct);
            }

            return default;
        }

        private class ServerStatusHint
        {
            public readonly MaintenanceModeHint MaintenanceMode; // 0x10

            private ServerStatusHint(MaintenanceModeHint maintenanceMode)
            {
                MaintenanceMode = maintenanceMode;
            }

            public static ServerStatusHint TryParseFromRecord(ServerStatusHintJsonRecord record)
            {
                if (record.MaintenanceMode == null || record.MaintenanceMode.StartAt == null && record.MaintenanceMode.EstimatedEndTime == null)
                    return new ServerStatusHint(null);

                var wasParsed = DateTime.TryParse(record.MaintenanceMode.StartAt, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var startDate);
                if (!wasParsed)
                    return null;

                if (record.MaintenanceMode.EstimatedEndTime == null)
                    return new ServerStatusHint(new MaintenanceModeHint(startDate, null));

                wasParsed = DateTime.TryParse(record.MaintenanceMode.EstimatedEndTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var estimatedDate);
                if (!wasParsed)
                    return null;

                return new ServerStatusHint(new MaintenanceModeHint(startDate, estimatedDate));
            }

            public static ServerStatusHint ForFetchFailure()
            {
                return new ServerStatusHint(null);
            }

            public class MaintenanceModeHint
            {
                public readonly DateTime StartTime; // 0x10
                public readonly DateTime? EstimatedEndTime; // 0x18

                public MaintenanceModeHint(DateTime startTime, DateTime? estimatedEndTime)
                {
                    StartTime = startTime;
                    EstimatedEndTime = estimatedEndTime;
                }

                public MetaTime GetStartAtMetaTime()
                {
                    return MetaTime.FromDateTime(StartTime);
                }

                public MetaTime? GetEstimatedMaintenanceOverAtMetaTimeMaybe()
                {
                    if (!EstimatedEndTime.HasValue)
                        return null;

                    return MetaTime.FromDateTime(EstimatedEndTime.Value);
                }
            }
        }

        private class ServerStatusHintJsonRecord
        {
            public MaintenanceModeRecord MaintenanceMode; // 0x10

            public class MaintenanceModeRecord
            {
                public string StartAt; // 0x10
                public string EstimatedEndTime; // 0x18
            }
        }

        public class ConfigResourceLoader : SessionResourceLoader
        {
            private Dictionary<ClientSlot, DownloadTaskWrapper<ConfigArchive>> _configArchiveDownloads; // 0x28
            private Dictionary<ClientSlot, DownloadTaskWrapper<GameConfigSpecializationPatches>> _patchArchiveDownloads; // 0x30
            private ClientSessionNegotiationResources _negotiationResources; // 0x38

            public ClientSessionNegotiationResources NegotiationResources => _negotiationResources;

            public ConfigResourceLoader(/*LogChannel log,*/ CancellationToken ct) : base(/*log,*/ ct)
            {
                _configArchiveDownloads = new Dictionary<ClientSlot, DownloadTaskWrapper<ConfigArchive>>();
                _patchArchiveDownloads = new Dictionary<ClientSlot, DownloadTaskWrapper<GameConfigSpecializationPatches>>();
            }

            protected override void Activate()
            {
                foreach (var value in _configArchiveDownloads)
                    _negotiationResources.ConfigArchives[value.Key] = value.Value.GetResult();
                foreach (var value in _patchArchiveDownloads)
                    _negotiationResources.PatchArchives[value.Key] = value.Value.GetResult();
            }

            public override void Reset()
            {
                foreach (var value in _configArchiveDownloads.Values)
                    value.Dispose();
                foreach (var value in _patchArchiveDownloads.Values)
                    value.Dispose();

                _configArchiveDownloads.Clear();
                _patchArchiveDownloads.Clear();
                _negotiationResources = new ClientSessionNegotiationResources();
                IsComplete = true;
            }

            public override void SetupFromResourceCorrection(SessionProtocol.SessionResourceCorrection resourceCorrection)
            {
                Reset();

                foreach (var configUpdate in resourceCorrection.ConfigUpdates)
                {
                    var (clientSlot, updateInfo) = configUpdate;
                    var configArchive = new DownloadTaskWrapper<ConfigArchive>(MetaplaySDK.Connection.DownloadConfigArchiveAsync("SharedGameConfig", updateInfo.SharedGameConfigVersion, updateInfo.UrlSuffix, _ct));

                    _configArchiveDownloads[clientSlot] = configArchive;
                }

                foreach (var patchUpdate in resourceCorrection.PatchUpdates)
                {
                    var (clientSlot, updateInfo) = patchUpdate;
                    var patch = new DownloadTaskWrapper<GameConfigSpecializationPatches>(MetaplaySDK.Connection.DownloadConfigPatchesAsync(updateInfo.PatchesVersion, _ct));

                    _patchArchiveDownloads[clientSlot] = patch;
                }

                if (_configArchiveDownloads.Count < 1)
                    if (_patchArchiveDownloads.Count < 1)
                        return;

                IsComplete = false;
            }

            public override bool PollDownload(out TransientError error)
            {
                error = null;
                var totalComplete = true;

                foreach (var update in _configArchiveDownloads)
                {
                    PollSingleDownload(update.Key, update.Value, out var isComplete, out error);
                    totalComplete &= isComplete;
                }

                foreach (var update in _patchArchiveDownloads)
                {
                    PollSingleDownload(update.Key, update.Value, out var isComplete, out error);
                    totalComplete &= isComplete;
                }

                return totalComplete;
            }

            private void PollSingleDownload(ClientSlot slot, IDownload task, out bool isComplete, out TransientError error)
            {
                error = null;

                switch (task.Status.Code)
                {
                    case DownloadStatus.StatusCode.Completed:
                        break;

                    case DownloadStatus.StatusCode.Timeout:
                        // Log debug "Timeout while fetching resource for slot {slot}"
                        error = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.ResourceFetch);
                        break;

                    case DownloadStatus.StatusCode.Error:
                        // Log debug "Failure while fetching resource for slot {slot}: {task.Status.Code}"
                        error = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.ResourceFetch);
                        break;

                    default:
                        isComplete = false;
                        return;

                }

                isComplete = true;
            }

            protected override void Specialize(SessionProtocol.SessionStartSuccess sessionStartSuccess)
            {
                var startResources = ClientSessionStartResources.SpecializeResources(sessionStartSuccess, _negotiationResources, (archive, tuple) =>
                {
                    if (!tuple.HasValue)
                        return GameConfigFactory.Instance.ImportSharedGameConfig(PatchedConfigArchive.WithNoPatches(archive));

                    var specPatches = tuple.Value.Item1.GetPatchesForSpecialization(tuple.Value.Item2);
                    return GameConfigFactory.Instance.ImportSharedGameConfig(new PatchedConfigArchive(archive, specPatches));
                });

                MetaplaySDK.Connection.SessionStartResources = startResources;
                var playerArchive = _negotiationResources.ConfigArchives[ClientSlotCore.Player];
                var patches = _negotiationResources.PatchArchives.GetValueOrDefault(ClientSlotCore.Player);
                var patchesVersion = patches?.Version ?? ContentHash.None;

                if (!_negotiationResources.PatchArchives.ContainsKey(ClientSlotCore.Player))
                    MetaplaySDK.Connection.LatestGameConfigInfo = new ConnectionGameConfigInfo(playerArchive.Version, patchesVersion, null);
                else
                {
                    var experiments = sessionStartSuccess.ActiveExperiments.Select(x => new ExperimentVariantPair(x.ExperimentId, x.VariantId)).ToList();
                    MetaplaySDK.Connection.LatestGameConfigInfo = new ConnectionGameConfigInfo(playerArchive.Version, patchesVersion, experiments);
                }
            }
        }

        private class LocalizationResourceLoader : DownloadResourceLoader // TypeDefIndex: 12689
        {
            public LocalizationResourceLoader(/*LogChannel log,*/ CancellationToken ct) : base(/*log,*/ ct)
            { }

            protected override void Activate()
            {
                if (Download is MetaplayLocalizationManager.LocalizationDownload ld)
                    ld.SetAsActiveLocalization();
            }

            public override void SetupFromResourceCorrection(SessionProtocol.SessionResourceCorrection resourceCorrection)
            {
                var langUpdate = resourceCorrection.LanguageUpdate;
                if (!langUpdate.HasValue)
                {
                    Reset();
                    return;
                }

                var download = MetaplaySDK.LocalizationManager.BeginFetchLanguage(langUpdate.Value.ActiveLanguage, langUpdate.Value.LocalizationVersion, _ct);

                // HINT: This code was inlined, but that's what the method is supposed for in the base class
                SetupWithDownload(download);
            }
        }

        private abstract class DownloadResourceLoader : SessionResourceLoader
        {
            protected IDownload Download { get; set; }  // 0x28

            protected DownloadResourceLoader( /*LogChannel log,*/ CancellationToken ct) : base( /*log,*/ ct)
            { }

            public sealed override bool PollDownload(out TransientError error)
            {
                error = null;

                if (Download == null)
                    return false;

                switch (Download.Status.Code)
                {
                    case DownloadStatus.StatusCode.Completed:
                        break;

                    case DownloadStatus.StatusCode.Timeout:
                        // Debug log: Timeout while fetching resource
                        error = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.ResourceFetch);
                        break;

                    case DownloadStatus.StatusCode.Error:
                        // Debug log: Failure while fetching resource: {State}
                        error = new TransientError.ConfigFetchFailed(Download.Status.Error, TransientError.ConfigFetchFailed.FailureSource.ResourceFetch);
                        break;

                    default:
                        return false;
                }

                return true;
            }

            public override void Reset()
            {
                Download?.Dispose();

                Download = null;
                IsComplete = true;
            }

            protected void SetupWithDownload(IDownload download)
            {
                Reset();

                Download = download;
                IsComplete = false;
            }
        }

        public abstract class SessionResourceLoader
        {
            //protected LogChannel _log; // 0x10
            protected CancellationToken _ct; // 0x18

            public bool IsComplete { get; set; } // 0x20

            protected SessionResourceLoader(/*LogChannel log,*/ CancellationToken ct)
            {
                _ct = ct;
                IsComplete = true;
            }

            public TransientError TryActivate()
            {
                Activate();
                IsComplete = true;

                return null;
            }

            public TransientError.ConfigFetchFailed TrySpecialize(SessionProtocol.SessionStartSuccess sessionStartSuccess)
            {
                Specialize(sessionStartSuccess);
                return null;
            }

            // Slot: 4; 0x178; 0x180
            public virtual void Reset()
            {
                IsComplete = true;
            }

            // Slot: 5; 0x188; 0x190
            public abstract void SetupFromResourceCorrection(SessionProtocol.SessionResourceCorrection resourceCorrection);

            // Slot: 6; 0x198; 0x1A0
            public abstract bool PollDownload(out TransientError error);

            // Slot: 7; 0x1A8; 0x1B0
            protected abstract void Activate();

            // Slot: 8; 0x1b8; 0x1c0
            protected virtual void Specialize(SessionProtocol.SessionStartSuccess sessionStartSuccess)
            { }
        }

        private enum Marker
        {
            UpdateComplete = 0,
            HandleMessagesAndCallAgain = 1
        }
    }
}

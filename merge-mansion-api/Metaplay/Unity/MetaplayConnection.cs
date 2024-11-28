using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Client.Messages;
using Metaplay.Core;
using Metaplay.Core.Client;
using Metaplay.Core.Config;
using Metaplay.Core.Debugging;
using Metaplay.Core.Localization;
using Metaplay.Core.Message;
using Metaplay.Core.Network;
using Metaplay.Core.Player;
using Metaplay.Core.Serialization;
using Metaplay.Network;
using Metaplay.Unity.ConnectionStates;
using Newtonsoft.Json;
using UnityEngine;

namespace Metaplay.Unity
{
    public sealed class MetaplayConnection
    {
        public ConnectionConfig Config; // 0x30

        public ClientSessionStartResources SessionStartResources; // 0x78

        private DeviceCredentials _credentials; // 0x88
        private bool _credentialsPendingIOError; // 0x90
        private ServerConnection _serverConnection; // 0x98
        private IEnumerator<Marker> _supervisionLoop; // 0xA0
        private CancellationTokenSource _cancellation; // 0xA8
        private bool _flushEnqueuedMessagesBeforeClose; // 0xB0
        private bool _supervisionLoopRunning; // 0xB1
        private List<MetaMessage> _messagesToDispatch; // 0xB8
        private ConnectionStatistics _statistics; // 0xC0
        private IMetaplayConnectionSDKHook _sdkHook; // 0xC8

        private bool _messageDispatchSuspended; // 0xD0
        private List<MetaMessage> _suspendedDispatchMessages; // 0xD8
        //private LogHandlerForwardingBuffer _logForwardingBuffer; // 0xE0
        private MetaplayOfflineOptions _offlineOptions; // 0xE8
        private SessionNonceService _sessionNonceService; // 0xF0
        private UnitySessionGuidService _sessionGuidService; // 0xF8

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
        public Handshake.ServerOptions ServerOptions { get; set; }

        // 0x80
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
            // Log = MetaplaySDK.IncidentTracker;
            _offlineOptions = offlineOptions;

            State = new NotConnected();
            Config = config ?? new ConnectionConfig();

            _supervisionLoopRunning = false;
            _supervisionLoop = null;
            _cancellation = null;
            _serverConnection = null;

            _messagesToDispatch = new List<MetaMessage>();
            _statistics = ConnectionStatistics.CreateNew();
            // _logForwardingBuffer = new LogHandlerForwardingBuffer(Log, 100, TimeSpan.FromSeconds(5));

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
            else
                ; // Log debug "Found credentials: deviceId={DeviceId}, playerId={PlayerId}"

            _sessionNonceService = new SessionNonceService(MetaplaySDK.AppLaunchId);
            _sessionGuidService = new UnitySessionGuidService(sdkHook);
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
                DeviceInfo = new SessionProtocol.ClientDeviceInfo
                {
                    DeviceModel = SystemInfo.DeviceModel,
                    ClientPlatform = ClientPlatform.Android,
                    OperatingSystem = string.Empty
                },
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

            return new ServerConnection(serverConnectionConfig, Endpoint, _sessionNonceService, _sessionGuidService, createTransport, MetaplaySDK.BuildVersion,
                loginCreds, initialResourceProposal, initialPauseStatus, Delegate.GetLoginDebugDiagnostics, MetaplaySDK.MessageDispatcher.InterceptMessage,
                true, MetaplaySDK.IncidentTracker.ReportWatchdogDeadlineExceededError, numFailedConnectionAttempts, true);
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
            transportConfig.ClientSessionConnectionNdx = _sessionNonceService.GetSessionConnectionIndex();
            transportConfig.ClientSessionNonce = _sessionNonceService.GetSessionNonce();
            transportConfig.AppLaunchId = _sessionNonceService.GetTransportAppLaunchId();
            transportConfig.Platform = ClientPlatform.Android;
            transportConfig.LoginProtocolVersion = 2;
            transportConfig.ConnectTimeout = timeout;
            transportConfig.HeaderReadTimeout = Config.ServerIdentifyTimeout == MetaDuration.Zero ?
                TimeSpan.FromMilliseconds(-1) :
                Config.ServerIdentifyTimeout.ToTimeSpan();
            transportConfig.DnsCacheMaxTTL = TimeSpan.FromMinutes(5);
            transportConfig.ServerHostIPv4 = MetaplayHostnameUtil.GetV4V6SpecificHost(gateway.ServerHost, true);
            transportConfig.ServerHostIPv6 = MetaplayHostnameUtil.GetV4V6SpecificHost(gateway.ServerHost, false);
            transportConfig.ServerPort = gateway.ServerPort;

            // Log info "Opening connection to {ServerHost}:{ServerPort} (tls={EnableTls})"

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

        // Version 23.06.01
        private IEnumerator<Marker> SupervisionLoop(CancellationToken ct)
        {
            /*		private int <>1__state; // 0x10
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
	                private ErrorState <sessionStartError>5__10; // 0x68
	                private MetaplayConnection.ConfigResourceLoader <configResourceLoader>5__11; // 0x70
	                private List<MetaplayConnection.SessionResourceLoader> <sessionResourceLoaders>5__12; // 0x78
	                private ScheduledMaintenanceMode <latestConnectionScheduledMaintenanceMode>5__13; // 0x80
	                private Handshake.ServerOptions <latestServerOptions>5__14; // 0x88
	                private ClientAppPauseStatus <lastConnectionPauseStatus>5__15; // 0xB0
	                private int <lastSentSessionResumptionPingId>5__16; // 0xB4
	                private int <lastReceivedSessionResumptionPongId>5__17; // 0xB8
	                private MetaTime <lastSessionResumptionPingSentAt>5__18; // 0xC0
	                private int <lastIncidentReportedSessionResumptionPingId>5__19; // 0xC8
	                private int <numSessionResumptionPingIncidentsReported>5__20; // 0xCC
	                private NetworkProbe <networkProbe>5__21; // 0xD0
	                private Task<ServerConnection> <connectTask>5__22; // 0xD8
	                private bool <loggedIn>5__23; // 0xE0
	                private bool <isConnected>5__24; // 0xE1
	                private MetaTime <connectOrReconnectStartedAt>5__25; // 0xE8
	                private Nullable<MetaTime> <sessionInitRequestTimeoutAt>5__26; // 0xF0
	                private MessageTransport.Error <connectionError>5__27; // 0x100
	                private SessionProtocol.SessionStartAbortReasonTrailer <reasonTrailer>5__28; // 0x108
	                private Task <closeTask>5__29; // 0x110
	                private IHasNetworkDiagnosticReport <report>5__30; // 0x118 */

            // L254
            var messageBuffer = new List<MetaMessage>();
            var delayedLoginMessageBuffer = new List<MetaMessage>();
            var qosMonitor = new TransportQosMonitor();

            Task<NetworkDiagnosticReport> networkDiagnosticReportTask = null;
            Task<ServerStatusHint> serverStatusHintFetchTask = null;
            var numConnectAttempts = 0;
            MetaTime latestMessagesTimestamp = default;

            // L273
            var configResourceLoader = new ConfigResourceLoader(ct);
            var sessionResourceLoaders = new List<SessionResourceLoader>();

            // L288
            var lastSentSessionResumptionPingId = 0;
            var lastReceivedSessionResumptionPongId = 0;
            ScheduledMaintenanceModeForClient latestConnectionScheduledMaintenanceMode = null;
            Handshake.ServerOptions latestServerOptions = default;

            // L296
            var lastSessionResumptionPingSentAt = MetaTime.Epoch;
            var lastIncidentReportedSessionResumptionPingId = 0;
            var numSessionResumptionPingIncidentsReported = 0;

            // L303
            State = new Connecting(0);

            // L307
            sessionResourceLoaders.Add(configResourceLoader);

            // L312
            var networkProbe = NetworkProbe.TestConnectivity(Endpoint);

            // L315
            if (_credentialsPendingIOError)
            {
                // L1257
                // Log debug "Failure while updating credentials to disk."

                var cannotConnectError = new TerminalError.ClientSideConnectionError(new CannotWriteCredentialsOnDiskError());

                // L1790
                SendReport(cannotConnectError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                TerminateConnection(sessionResourceLoaders, ref networkProbe);
                yield break;
            }

            // CUSTOM: Initialize state variables to null for default state
            ConnectionState sessionStartError = null;
            MetaTime connectOrReconnectStartedAt;

            do
            {
                // L326
                foreach (var loader in sessionResourceLoaders)
                    loader.Reset();

                // L347
                var lastConnectionPauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);

                // L361
                var connectTask = CreateConnection(configResourceLoader.NegotiationResources.ToResourceProposal(), lastConnectionPauseStatus);
                connectTask.Wait(ct);

                if (ct.IsCancellationRequested)
                {
                    TerminateConnection(sessionResourceLoaders, ref networkProbe);
                    yield break;
                }

                // L389
                _serverConnection = connectTask.Result;

                // L390
                networkDiagnosticReportTask = null;

                // L391
                qosMonitor.Reset();
                delayedLoginMessageBuffer.Clear();

                // L408
                MetaplaySDK.MessageDispatcher.SetConnection(this);

                // L421
                var loggedIn = false;
                var isConnected = false;
                connectOrReconnectStartedAt = MetaTime.Now;
                MetaTime? sessionInitRequestTimeoutAt = null;

            // L429
            ReceiveMessages:
                var receiveMessageError = _serverConnection.ReceiveMessages(messageBuffer);
                qosMonitor.ProcessMessages(messageBuffer, _serverConnection.IsLoggedIn);

                // L439
                foreach (var msg in messageBuffer)
                {
                    if (msg is ConnectedToServer cts)
                    {
                        // L863
                        if (!Endpoint.IsOfflineMode)
                        {
                            var cdnAddress = MetaplayCdnAddress.Create(Endpoint.CdnBaseUrl, cts.IsIPv4);
                            _sdkHook.OnCurrentCdnAddressUpdated(cdnAddress);
                        }
                        else
                        {
                            var cdnAddress = MetaplayCdnAddress.Empty;
                            _sdkHook.OnCurrentCdnAddressUpdated(cdnAddress);
                        }

                        // L946
                        LatestTlsPeerDescription = cts.TlsPeerDescription;

                        // L952
                        var primaryUrl = MetaplaySDK.CdnAddress.PrimaryBaseUrl;
                        var backupGateways = Endpoint.BackupGateways.ToList();

                        Endpoint = new ServerEndpoint(Endpoint.ServerHost, Endpoint.ServerPort, Endpoint.EnableTls, primaryUrl, backupGateways);

                        // L986
                        latestMessagesTimestamp = MetaTime.Now;
                        _statistics.CurrentConnection.HasCompletedHandshake = true;
                        isConnected = true;

                        // L993
                        Delegate.OnHandshakeComplete();
                    }
                    else if (msg is Handshake.ClientHelloAccepted cha)
                    {
                        // L851
                        latestServerOptions = cha.ServerOptions;
                    }
                    else if (msg is SessionProtocol.SessionStartSuccess sss)
                    {
                        // L730
                        loggedIn = true;
                        latestConnectionScheduledMaintenanceMode = sss.ScheduledMaintenanceMode;
                        sessionInitRequestTimeoutAt = null;

                        // L747
                        foreach (var loader in sessionResourceLoaders)
                        {
                            var error = loader.TrySpecialize(sss);
                            if (error == null)
                                continue;

                            sessionStartError = error;
                            break;
                        }

                        // L778
                        if (sessionStartError != null)
                        {
                            CloseSupervisionLoop(sessionStartError, latestServerOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                            TerminateConnection(sessionResourceLoaders, ref networkProbe);
                            yield break;
                        }

                        // L790
                        ServerOptions = latestServerOptions;

                        // L804
                        _sdkHook.OnSessionStarted(sss);
                        Delegate.OnSessionStarted(SessionStartResources);
                    }
                    else if (msg is UpdateScheduledMaintenanceMode usmm)
                    {
                        // L726
                        latestConnectionScheduledMaintenanceMode = usmm.ScheduledMaintenanceMode;
                    }
                    else if (msg is MessageTransportInfoWrapperMessage mtiwm)
                    {
                        // L535
                        if (mtiwm.Info is ServerConnection.GotServerHello gsh)
                        {
                            // L716
                            LatestServerVersion = gsh.ServerHello.ServerVersion;
                        }
                        else if (mtiwm.Info is ServerConnection.LoginCredentialsChangedInfo lcci)
                        {
                            // L683
                            var handled = HandleCredentialsChanged(lcci);
                            if (!handled)
                            {
                                // Log debug "Failure while writing credentials to disk."
                                sessionStartError = new TerminalError.ClientSideConnectionError(new CannotWriteCredentialsOnDiskError());

                                CloseSupervisionLoop(sessionStartError, latestServerOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                                TerminateConnection(sessionResourceLoaders, ref networkProbe);
                                yield break;
                            }
                        }
                        else if (mtiwm.Info is ServerConnection.ResourceCorrectionInfo rci)
                        {
                            // L642
                            sessionInitRequestTimeoutAt = null;

                            foreach (var loader in sessionResourceLoaders)
                                loader.SetupFromResourceCorrection(rci.ResourceCorrection);
                        }
                        else if (mtiwm.Info is ServerConnection.FullProtocolHashMismatchInfo fphmi)
                        {
                            // L608
                            Delegate.OnFullProtocolHashMismatch(fphmi.ClientProtocolHash, fphmi.ServerProtocolHash);
                        }
                        else if (mtiwm.Info is ServerConnection.SessionStartRequested)
                        {
                            // L587
                            sessionInitRequestTimeoutAt = MetaTime.Now + Config.ServerSessionInitTimeout;
                        }
                    }
                    else if (msg is Handshake.OperationStillOngoing)
                    {
                        // L503
                        sessionInitRequestTimeoutAt = MetaTime.Now + Config.ServerSessionInitTimeout;
                    }
                }

                // L1024
                if (messageBuffer.Count > 0)
                    latestMessagesTimestamp = MetaTime.Now;

                // L1032
                delayedLoginMessageBuffer.AddRange(messageBuffer);
                messageBuffer.Clear();

                // L1051
                _statistics.CurrentConnection.NetworkProbeStatus = networkProbe.TryGetConnectivityState();

                // L1054
                if (receiveMessageError == null)
                {
                    // L1055
                    if (sessionInitRequestTimeoutAt.HasValue)
                    {
                        // L1065
                        if (MetaTime.Now >= sessionInitRequestTimeoutAt.Value)
                        {
                            // L1074
                            // Log warning "Timeout while waiting for session init response from server."

                            // L1093
                            sessionStartError = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.Stream);

                            CloseSupervisionLoop(sessionStartError, latestServerOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                            TerminateConnection(sessionResourceLoaders, ref networkProbe);
                            yield break;
                        }
                    }

                    // L1130
                    var allActivated = false;
                    var allPolled = true;

                    // L1452
                    foreach (var loader in sessionResourceLoaders)
                    {
                        // L1642
                        if (loader.IsComplete)
                            continue;

                        // L1651
                        if (!loader.PollDownload(out var pollError))
                        {
                            allPolled = false;
                            continue;
                        }

                        // L1448
                        if (pollError == null)
                        {
                            // L1449
                            pollError = loader.TryActivate();
                            allActivated = true;
                        }

                        // L1451
                        if (pollError == null)
                            continue;

                        // L1657
                        CloseSupervisionLoop(pollError, latestServerOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                        TerminateConnection(sessionResourceLoaders, ref networkProbe);
                        yield break;
                    }

                    // L1465
                    if (allPolled && allActivated)
                    {
                        // L1468
                        var resourceProposal = configResourceLoader.NegotiationResources.ToResourceProposal();
                        lastConnectionPauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);

                        // L1488
                        _serverConnection.RetrySessionStart(resourceProposal, lastConnectionPauseStatus);
                    }

                    // L1502
                    if (!loggedIn)
                    {
                        // L1503
                        if (!isConnected && serverStatusHintFetchTask == null)
                        {
                            // L1504
                            if (MetaTime.Now >= connectOrReconnectStartedAt + Config.ServerStatusHintCheckDelay)
                                serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);
                        }

                        // L1520
                        if (serverStatusHintFetchTask != null)
                        {
                            serverStatusHintFetchTask.Wait(ct);

                            if (ct.IsCancellationRequested)
                            {
                                CloseSupervisionLoop(sessionStartError, latestServerOptions, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                                TerminateConnection(sessionResourceLoaders, ref networkProbe);
                                yield break;
                            }

                            // L1529
                            var maintenanceMode = serverStatusHintFetchTask.Result.MaintenanceMode;
                            if (maintenanceMode != null)
                            {
                                // L1868
                                var start = maintenanceMode.GetStartAtMetaTime();
                                var estimated = maintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                                var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                                // L1895
                                _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);

                                // L2397
                                State = new TerminalError.InMaintenance();

                                TerminateConnection(sessionResourceLoaders, ref networkProbe);
                                yield break;
                            }
                        }

                        goto ReceiveMessages;
                    }

                    // L1534
                    _statistics.CurrentConnection.HasCompletedSessionInit = true;

                    // L1535
                    State = new Connected(qosMonitor.IsHealthy, latestMessagesTimestamp);

                    // L1542
                    var pauseStatus = ToClientAppPauseStatus(MetaplaySDK.ApplicationPauseStatus);
                    if (lastConnectionPauseStatus != pauseStatus)
                    {
                        // L1557
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

                    // L1608
                    _messagesToDispatch.AddRange(delayedLoginMessageBuffer);
                    delayedLoginMessageBuffer.Clear();

                    // L1628
                    var maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(latestConnectionScheduledMaintenanceMode);

                    // L1932
                    _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);

                // L1938
                ReceiveMessages2:
                    var connectionError = _serverConnection.ReceiveMessages(messageBuffer);
                    qosMonitor.ProcessMessages(messageBuffer, _serverConnection.IsLoggedIn);

                    // L1951
                    var msgCount = messageBuffer.Count;
                    foreach (var msg in messageBuffer)
                    {
                        // L1967
                        if (msg == null)
                            continue;

                        // L1968
                        if (msg is SessionProtocol.SessionResumeSuccess srs)
                        {
                            // L2050
                            latestConnectionScheduledMaintenanceMode = srs.ScheduledMaintenanceMode;

                            maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(srs.ScheduledMaintenanceMode);
                            _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);

                            // L2086
                            lastSentSessionResumptionPingId++;
                            _serverConnection.EnqueueSendMessage(new SessionPing(lastSentSessionResumptionPingId));

                            // L2100
                            lastSessionResumptionPingSentAt = MetaTime.Now;
                        }
                        else if (msg is SessionPong sp)
                        {
                            // L2046
                            lastReceivedSessionResumptionPongId = sp.Id;
                        }
                        else if (msg is UpdateScheduledMaintenanceMode usmm)
                        {
                            // L2007
                            latestConnectionScheduledMaintenanceMode = usmm.ScheduledMaintenanceMode;

                            maintenanceState = ScheduledMaintenanceModeToMaintenanceModeState(usmm.ScheduledMaintenanceMode);
                            _sdkHook.OnScheduledMaintenanceModeUpdated(maintenanceState);
                        }
                        else if (msg is Handshake.ClientHelloAccepted cha)
                        {
                            // L1995
                            latestServerOptions = cha.ServerOptions;
                        }
                    }

                    // L2110
                    _messagesToDispatch.AddRange(messageBuffer);
                    messageBuffer.Clear();

                    // L2129
                    _statistics.CurrentConnection.NetworkProbeStatus = networkProbe.TryGetConnectivityState();

                    // L2132
                    if (msgCount > 0)
                        latestMessagesTimestamp = MetaTime.Now;

                    // L2139
                    if (connectionError == null)
                    {
                        // L2140
                        if (ShouldEndSessionDueToRecentPause)
                        {
                            // L2265
                            // Log debug "A long duration in background just ended, will end session"
                            State = new TransientError.SessionLostInBackground();

                            _messagesToDispatch.Add(new DisconnectedFromServer());
                        }
                        else
                        {
                            // L2142
                            if (msgCount < 1 && allActivated)
                                State = new Connected(lastSentSessionResumptionPingId == lastReceivedSessionResumptionPongId && qosMonitor.IsHealthy, latestMessagesTimestamp);

                            // L2154
                            var unpauseTime = MetaplaySDK.ApplicationLastPauseBeganAt + MetaplaySDK.ApplicationLastPauseDuration;
                            if (lastSentSessionResumptionPingId != lastReceivedSessionResumptionPongId && lastSentSessionResumptionPingId != lastIncidentReportedSessionResumptionPingId)
                            {
                                if (numSessionResumptionPingIncidentsReported < Config.MaxSessionPingPongDurationIncidentsPerSession)
                                {
                                    if (MetaplaySDK.ApplicationPauseStatus == ApplicationPauseStatus.Running)
                                    {
                                        if (MetaTime.Now > unpauseTime + MetaDuration.FromSeconds(5))
                                        {
                                            // L2202
                                            var lastPingTime = MetaTime.Now - lastSessionResumptionPingSentAt;
                                            var connectedDuration = MetaDuration.FromTimeSpan(_serverConnection._statistics.DurationToConnected);
                                            var pingThreshold = connectedDuration + Config.SessionPingPongDurationIncidentThreshold;

                                            if (lastPingTime > pingThreshold)
                                            {
                                                // L2219
                                                var loginDiag = Delegate.GetLoginDebugDiagnostics(true);
                                                MetaplaySDK.IncidentTracker.ReportSessionPingPongDurationThresholdExceeded(loginDiag, connectedDuration, _serverConnection._currentGateway, lastSentSessionResumptionPingId, lastPingTime);

                                                lastIncidentReportedSessionResumptionPingId = lastSentSessionResumptionPingId;
                                                numSessionResumptionPingIncidentsReported++;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // L2279
                        yield return Marker.HandleMessagesAndCallAgain;

                        if (HandleAndCall(connectionError, ct))
                            goto ReceiveMessages2;

                        TerminateConnection(sessionResourceLoaders, ref networkProbe);
                        yield break;
                    }

                    // L2283
                    var connectionState = TranslateError(connectionError);
                    // Log debug "Failure during session. {connectionError}, causes {connectionState}"

                    // L2294
                    if (!(connectionState is TerminalError.InMaintenance))
                    {
                        State = TranslateConnectionErrorForUser(connectionState);

                        // L2279
                        yield return Marker.HandleMessagesAndCallAgain;

                        if (HandleAndCall(connectionError, ct))
                            goto ReceiveMessages2;

                        TerminateConnection(sessionResourceLoaders, ref networkProbe);
                        yield break;
                    }

                    // L2307
                    if (latestConnectionScheduledMaintenanceMode == null)
                    {
                        // L2309
                        var ongoing = MaintenanceModeState.CreateOngoing(MetaTime.Now, null);
                        _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                    }
                    else
                    {
                        // L2340
                        MetaTime? estimated = null;
                        if (latestConnectionScheduledMaintenanceMode.EstimationIsValid)
                            estimated = latestConnectionScheduledMaintenanceMode.StartAt + MetaDuration.FromMinutes(latestConnectionScheduledMaintenanceMode.EstimatedDurationInMinutes);

                        // L2360
                        var ongoing = MaintenanceModeState.CreateOngoing(latestConnectionScheduledMaintenanceMode.StartAt, estimated);
                        _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                    }

                    // L2397
                    State = new TerminalError.InMaintenance();

                    TerminateConnection(sessionResourceLoaders, ref networkProbe);
                    yield break;
                }

                // L1119
                if (receiveMessageError is ServerConnection.RedirectToServerError rtse)
                {
                    // L1248
                    // Log info "Redirecting to server: {rtse.RedirectToServer}"
                    Endpoint = rtse.RedirectToServer;
                    continue;
                }

                // L1126
                var translatedState = TranslateError(receiveMessageError);
                // Log debug "Failure while connecting. {receiveMessageError}, causes {translatedState}"

                // L1146
                if (translatedState is TransientError)
                {
                    // L1171
                    networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
                    serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);

                    // L1182
                    numConnectAttempts++;

                    // L1185
                    if (numConnectAttempts >= Config.ConnectAttemptsMaxCount)
                    {
                        // L1187
                        serverStatusHintFetchTask?.Wait(ct);
                    }
                    else
                    {
                        // L1192
                        var connectingState = new Connecting(numConnectAttempts);

                        // L1196
                        _serverConnection?.Dispose();
                        _serverConnection = null;

                        // L1199
                        serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);

                        // L1205
                        connectOrReconnectStartedAt = MetaTime.Now + Config.ConnectAttemptInterval;
                        // Log info "Reconnecting in {ReconnectTimeout} (try {RetryCount} out of {MaxRetryCount})..."

                        // L1222
                        serverStatusHintFetchTask?.Wait(ct);

                        if (!ct.IsCancellationRequested)
                        {
                            var maintenanceMode = serverStatusHintFetchTask.Result.MaintenanceMode;

                            // L1868
                            var start = maintenanceMode.GetStartAtMetaTime();
                            var estimated = maintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                            var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                            // L1894
                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);

                            // L2395
                            State = new TerminalError.InMaintenance();
                        }

                        TerminateConnection(sessionResourceLoaders, ref networkProbe);
                        yield break;
                    }
                }
                else if (translatedState is TerminalError.InMaintenance)
                {
                    // L1162
                    serverStatusHintFetchTask ??= GetServerStatusHintAsync(Endpoint, Config);
                    serverStatusHintFetchTask.Wait(ct);

                    // L1387
                    if (ct.IsCancellationRequested)
                    {
                        TerminateConnection(sessionResourceLoaders, ref networkProbe);
                        yield break;
                    }

                    // L1396
                    var maintenanceMode1 = serverStatusHintFetchTask.Result.MaintenanceMode;
                    if (maintenanceMode1 != null)
                    {
                        // L1855
                        serverStatusHintFetchTask.Wait(ct);

                        if (!ct.IsCancellationRequested)
                        {
                            // L1868
                            var start = maintenanceMode1.GetStartAtMetaTime();
                            var estimated = maintenanceMode1.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                            var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                            // L1894
                            _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                        }
                    }
                    else
                    {
                        // L1403
                        var ongoing = MaintenanceModeState.CreateOngoing(MetaTime.Now, null);

                        // L1419
                        _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);
                    }

                    // L2395
                    State = new TerminalError.InMaintenance();

                    TerminateConnection(sessionResourceLoaders, ref networkProbe);
                    yield break;
                }

                // L1140
                var cannotConnectError = TranslateConnectionErrorForUser(translatedState);

                SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
                TerminateConnection(sessionResourceLoaders, ref networkProbe);
                yield break;
            } while (MetaTime.Now >= connectOrReconnectStartedAt);
        }

        // CUSTOM: Moves enumeration with HandleMessagesAndCallAgain and terminates connection when necessary
        private bool HandleAndCall(MessageTransport.Error connectionError, CancellationToken ct)
        {
            // L1287
            if (ct.IsCancellationRequested)
            {
                // L1298
                if (State.Status == ConnectionStatus.Connected)
                {
                    // L1312
                    if (_flushEnqueuedMessagesBeforeClose)
                    {
                        // L1314
                        // Log info "signaled connection to close, waiting"
                        Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                    }
                }
            }
            else
            {
                // L1289
                if (connectionError == null)
                {
                    // L1292
                    if (!ShouldEndSessionDueToRecentPause)
                    {
                        if (!ct.IsCancellationRequested)
                            return true;

                        // L1312
                        if (_flushEnqueuedMessagesBeforeClose)
                        {
                            // L1314
                            // Log info "signaled connection to close, waiting"
                            Task.WaitAny(_serverConnection.EnqueueCloseAsync(), Task.Delay((int)Config.CloseFlushTimeout.Milliseconds, ct));
                        }
                    }
                }
            }

            return false;
        }

        // CUSTOM: Closes the supervision loop connections
        private void CloseSupervisionLoop(ConnectionState sessionStartError, Handshake.ServerOptions latestServerOptions, CancellationToken ct, ref Task<ServerStatusHint> serverStatusHintFetchTask, ref Task<NetworkDiagnosticReport> networkDiagnosticReportTask)
        {
            // L1666
            // Log info "Client failed to start session. Sending failure report to server when network diagnostics complete."

            if (serverStatusHintFetchTask == null && sessionStartError is TransientError)
                serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);

            networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
            networkDiagnosticReportTask.Wait(ct);

            if (ct.IsCancellationRequested)
                return;

            SessionProtocol.SessionStartAbortReasonTrailer reasonTrailer = null;

            var failedReport = MetaplaySDK.IncidentTracker.TryCreateSessionStartFailureReport(sessionStartError, Endpoint, LatestTlsPeerDescription, networkDiagnosticReportTask.Result, false);
            if (failedReport == null)
            {
                // Log debug "Session start incident report throttled. Will not send the report."
            }
            else
            {
                var suffix = (uint)PlayerIncidentUtil.GetSuffixFromIncidentId(failedReport.ErrorType);
                var coinFlip = KeyedStableWeightedCoinflip.FlipACoin(0x1247a312, suffix, latestServerOptions.PushUploadPercentageSessionStartFailedIncidentReport * 10);
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
                        return;
                }

                // Log debug reasonTrailer != null ? "Session start incident report sent." : "Session start abort request sent."
            }

            var cannotConnectError = sessionStartError;
            SendReport(sessionStartError, cannotConnectError, ct, ref serverStatusHintFetchTask, ref networkDiagnosticReportTask);
        }

        // CUSTOM: Sends a report and other terminating behaviour
        private void SendReport(ConnectionState sessionStartError, ConnectionState cannotConnectError, CancellationToken ct, ref Task<ServerStatusHint> serverStatusHintFetchTask, ref Task<NetworkDiagnosticReport> networkDiagnosticReportTask)
        {
            // L1790
            if (serverStatusHintFetchTask == null && sessionStartError is TransientError)
                serverStatusHintFetchTask = GetServerStatusHintAsync(Endpoint, Config);

            // L1804
            var report = (IHasNetworkDiagnosticReport)sessionStartError;
            if (report != null)
            {
                // L1809
                networkDiagnosticReportTask ??= GetNetworkDiagnosticReportAsync();
                networkDiagnosticReportTask.Wait(ct);

                if (ct.IsCancellationRequested)
                    return;

                report.NetworkDiagnosticReport = networkDiagnosticReportTask.Result;
            }

            // L1847
            if (serverStatusHintFetchTask != null && cannotConnectError is TransientError)
            {
                // L1855
                serverStatusHintFetchTask.Wait(ct);

                if (ct.IsCancellationRequested)
                    return;

                // L1868
                var start = serverStatusHintFetchTask.Result.MaintenanceMode.GetStartAtMetaTime();
                var estimated = serverStatusHintFetchTask.Result.MaintenanceMode.GetEstimatedMaintenanceOverAtMetaTimeMaybe();
                var ongoing = MaintenanceModeState.CreateOngoing(start, estimated);

                _sdkHook.OnScheduledMaintenanceModeUpdated(ongoing);

                // L2395
                State = new TerminalError.InMaintenance();
            }
            else
                // L1917
                State = cannotConnectError;
        }

        // CUSTOM: Terminates connection instances in SupervisionLoop
        private void TerminateConnection(List<SessionResourceLoader> sessionResourceLoaders, ref NetworkProbe networkProbe)
        {
            // L2401
            // Log info "Connection terminated"

            _serverConnection?.Dispose();
            _serverConnection = null;

            foreach (var loader in sessionResourceLoaders)
                loader.Reset();

            MetaplaySDK.MessageDispatcher.SetConnection(null);

            networkProbe?.Dispose();
            networkProbe = null;
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

        private MaintenanceModeState ScheduledMaintenanceModeToMaintenanceModeState(ScheduledMaintenanceModeForClient scheduledMaintenanceMaybe)
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

            // HINT: This method got inlined in the original code, but it does exactly the same
            return CredentialsStore.StoreCredentials(credentials);
        }

        private static ClientAppPauseStatus ToClientAppPauseStatus(ApplicationPauseStatus status)
        {
            return (ClientAppPauseStatus)status;
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
            private DownloadTaskWrapper<LocalizationLanguage> _localizationDownload; // 0x38
            private ClientSessionNegotiationResources _negotiationResources; // 0x40

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

                if (_localizationDownload != null)
                    _negotiationResources.ActiveLanguage = _localizationDownload.GetResult();

                MetaplaySDK.LocalizationManager.ActivateSessionStartLanguage(_negotiationResources.ActiveLanguage);
            }

            public override void Reset()
            {
                foreach (var value in _configArchiveDownloads.Values)
                    value.Dispose();
                foreach (var value in _patchArchiveDownloads.Values)
                    value.Dispose();

                _configArchiveDownloads.Clear();
                _patchArchiveDownloads.Clear();

                _localizationDownload?.Dispose();
                _localizationDownload = null;

                _negotiationResources = new ClientSessionNegotiationResources
                {
                    ActiveLanguage = MetaplaySDK.ActiveLanguage
                };

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

                if (resourceCorrection.LanguageUpdate.HasValue)
                {
                    var update = resourceCorrection.LanguageUpdate.Value;
                    var config = MetaplaySDK.Connection.Config;

                    var fetchTask = MetaplaySDK.LocalizationManager.FetchLanguageAsync(update.ActiveLanguage, update.LocalizationVersion, MetaplaySDK.CdnAddress, config.ConfigFetchAttemptsMaxCount, config.ConfigFetchTimeout, _ct);
                    _localizationDownload = new DownloadTaskWrapper<LocalizationLanguage>(fetchTask);
                }

                if (_configArchiveDownloads.Count < 1 && _patchArchiveDownloads.Count < 1 && _localizationDownload == null)
                    return;

                IsComplete = false;
            }

            public override bool PollDownload(out TransientError error)
            {
                error = null;
                var totalComplete = true;

                foreach (var update in _configArchiveDownloads)
                {
                    PollSingleDownload($"slot {update.Key.Id}", update.Value, out var isComplete, out error);
                    totalComplete &= isComplete;
                }

                foreach (var update in _patchArchiveDownloads)
                {
                    PollSingleDownload($"slot {update.Key.Id}", update.Value, out var isComplete, out error);
                    totalComplete &= isComplete;
                }

                if (_localizationDownload != null)
                {
                    PollSingleDownload("localizations", _localizationDownload, out var isComplete, out error);
                    totalComplete &= isComplete;
                }

                return totalComplete;
            }

            private void PollSingleDownload(string resourceNameForErrorMessage, IDownload task, out bool isComplete, out TransientError error)
            {
                error = null;

                switch (task.Status.Code)
                {
                    case DownloadStatus.StatusCode.Completed:
                        break;

                    case DownloadStatus.StatusCode.Timeout:
                        // Log warning "Timeout while fetching resource for {resourceNameForErrorMessage}"
                        error = new TransientError.Timeout(TransientError.Timeout.TimeoutSource.ResourceFetch);
                        break;

                    case DownloadStatus.StatusCode.Error:
                        // Log warning "Failure while fetching resource for {resourceNameForErrorMessage}: {task.Status.Error}"
                        error = new TransientError.ConfigFetchFailed(task.Status.Error, TransientError.ConfigFetchFailed.FailureSource.ResourceFetch);
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

                var configs = _negotiationResources.ConfigArchives[ClientSlotCore.Player];
                var patches = _negotiationResources.PatchArchives.GetValueOrDefault(ClientSlotCore.Player);

                var archiveVersion = configs.Version;
                var patchesVersion = patches?.Version ?? ContentHash.None;

                if (!_negotiationResources.PatchArchives.ContainsKey(ClientSlotCore.Player))
                    MetaplaySDK.Connection.LatestGameConfigInfo = new ConnectionGameConfigInfo(archiveVersion, patchesVersion, null);
                //else
                //{
                //    var experiments = sessionStartSuccess.ActiveExperiments.Select(x => new ExperimentVariantPair(x.ExperimentId, x.VariantId)).ToList();
                //    MetaplaySDK.Connection.LatestGameConfigInfo = new ConnectionGameConfigInfo(archiveVersion, patchesVersion, experiments);
                //}
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

            // Slot: 4; 0x178
            public virtual void Reset()
            {
                IsComplete = true;
            }

            // Slot: 5; 0x188
            public abstract void SetupFromResourceCorrection(SessionProtocol.SessionResourceCorrection resourceCorrection);

            // Slot: 6; 0x198
            public abstract bool PollDownload(out TransientError error);

            // Slot: 7; 0x1A8
            protected abstract void Activate();

            // Slot: 8; 0x1B8
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

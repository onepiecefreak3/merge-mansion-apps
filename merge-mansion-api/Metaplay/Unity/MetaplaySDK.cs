using System;
using System.Collections.Generic;
using System.IO;
using Metaplay.Metaplay.Client.Messages;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.IO;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core.Player;
using Metaplay.UnityEngine;

namespace Metaplay.Metaplay.Unity
{
    public static class MetaplaySDK
    {
        // 0x168
        private static bool _maintenanceModeChanged; // 0x168

        // 0x8
        public static MessageDispatcher MessageDispatcher { get; set; }

        // 0x20
        public static PlayerIncidentRepository IncidentRepository { get; set; }
        // 0x28
        public static PlayerIncidentTracker IncidentTracker { get; set; }
        // 0x30
        public static PlayerIncidentUploader IncidentUploader { get; set; }
        // 0x38
        public static MetaplayConnection Connection { get; set; }
        // 0x40
        public static MetaplayLocalizationManager LocalizationManager { get; set; }
        // 0x48
        public static LocalizationLanguage ActiveLanguage { get; set; }
        // 0x50
        //public static SocialAuthManager SocialAuthentication { get; set; }
        // 0x58
        public static string DownloadCachePath { get; set; }
        // 0x60
        public static string LocalizationsDownloadPath { get; set; }
        // 0x68
        public static string LocalizationsBuiltinPath { get; set; }
        // 0x70
        public static Guid AppLaunchId;
        // 0x80
        public static MaintenanceModeState MaintenanceMode { get; set; }

        // 0xA8
        public static MetaTime ApplicationPreviousEndOfTheFrameAt { get; set; } = MetaTime.Now;
        // 0xB0
        public static MetaDuration ApplicationLastPauseDuration { get; set; }
        // 0xB8
        public static MetaTime ApplicationLastPauseBeganAt { get; set; }
        // 0xC0
        public static ApplicationPauseStatus ApplicationPauseStatus { get; set; }
        // 0xC8
        public static MetaDuration ApplicationPauseMaxDuration { get; set; }
        // 0xD0
        public static MetaDuration? ApplicationPauseDeclaredMaxDuration { get; set; }
        // 0xE0
        public static string ApplicationPauseReason { get; set; }
        // 0xE8
        public static MetaplayCdnAddress CdnAddress { get; set; }
        // 0xF0
        public static BuildVersion BuildVersion { get; set; }
        // 0x108
        private static string DeviceGuid { get; set; }

        private static int DeviceGuidFileVersion; // 0x128

        // 0x120
        public static Dictionary<PlayerExperimentId, ExperimentMembershipStatus> ActiveExperiments { get; set; }
        // 0x128
        public static string PersistentDataPath { get; set; }

        static MetaplaySDK()
        {
            AppLaunchId = Guid.NewGuid();
            PersistentDataPath = null;
            DeviceGuidFileVersion = 1;
        }

        public static void Start(MetaplaySDKConfig config)
        {
            // Z141 .. Z149
            PersistentDataPath = Application.PersistentDataPath;

            // ...

            // Z268 .. Z593
            MessageDispatcher = new MessageDispatcher();
            MessageDispatcher.AddListener<SessionPong>(OnIgnoredMessage);
            MessageDispatcher.AddListener<UpdateScheduledMaintenanceMode>(OnIgnoredMessage);
            MessageDispatcher.AddListener<SessionAcknowledgementMessage>(OnIgnoredMessage);
            MessageDispatcher.AddListener<ConnectedToServer>(OnIgnoredMessage);
            MessageDispatcher.AddListener<DisconnectedFromServer>(OnDisconnectedFromServer);
            MessageDispatcher.AddListener<Handshake.LoginResponse>(OnIgnoredMessage);
            MessageDispatcher.AddListener<SessionProtocol.SessionResumeSuccess>(OnIgnoredMessage);
            MessageDispatcher.AddListener<SessionProtocol.SessionStartFailure>(OnIgnoredMessage);
            MessageDispatcher.AddListener<ConnectionHandshakeFailure>(OnIgnoredMessage);
            MessageDispatcher.AddListener<MessageTransportInfoWrapperMessage>(OnIgnoredMessage);
            MessageDispatcher.AddListener<Handshake.OperationStillOngoing>(OnIgnoredMessage);

            // ...

            CdnAddress = CreateInitialCdnAddress(config.ServerEndpoint);
            DeviceGuid = ReadDeviceGuid();
            BuildVersion = new BuildVersion(config.BuildVersion.Version ?? "undefined", config.BuildVersion.BuildNumber ?? "undefined", config.BuildVersion.CommitId ?? "undefined");

            Connection = new MetaplayConnection(config.ServerEndpoint, config.ConnectionConfig, config.ConnectionDelegate, new MetaplayConnectionSDKHook(), config.OfflineOptions);

            // ...

            // Z743
            IncidentRepository = new PlayerIncidentRepository(Path.Combine(PersistentDataPath, "MetaplayIncidentReports"));
            IncidentTracker = new PlayerIncidentTracker(IncidentRepository);

            SetupIncidentUploader(config.ServerEndpoint);

            // Z825 .. Z846
            ActiveExperiments = new Dictionary<PlayerExperimentId, ExperimentMembershipStatus>();

            // ...

            DownloadCachePath = Path.Combine(PersistentDataPath, "GameConfigCache");
            LocalizationsDownloadPath = Path.Combine(DownloadCachePath, "Localizations");
            LocalizationsBuiltinPath = Path.Combine(Application.ApkPath, "Localizations");

            LocalizationManager = new MetaplayLocalizationManager(config.LocalizationDelegate);

            // ...

            LocalizationManager.AfterSDKInit();
            LocalizationManager.Start();
        }

        public static void Update()
        {
            // ...

            // Z181
            Connection.InternalUpdate();

            // ...
        }

        private static MetaplayCdnAddress CreateInitialCdnAddress(ServerEndpoint endpoint)
        {
            if (!endpoint.IsOfflineMode)
                return MetaplayCdnAddress.Create(endpoint.CdnBaseUrl, true);

            return MetaplayCdnAddress.Empty;
        }

        private static void SetupIncidentUploader(ServerEndpoint endpoint)
        {
            IncidentUploader?.Dispose();
            IncidentUploader = null;

            var pendingReports = IncidentRepository.ScanPendingReports();
            if (endpoint.IsOfflineMode)
                return;

            IncidentUploader = new PlayerIncidentUploader(IncidentRepository, IncidentTracker, pendingReports);
        }

        private static void OnIgnoredMessage(MetaMessage message)
        {
            throw new NotImplementedException();
        }

        private static void OnDisconnectedFromServer(MetaMessage message)
        {
            throw new NotImplementedException();
        }

        private static void SetMaintenanceMode(MaintenanceModeState maintenanceMode)
        {
            if (MaintenanceMode == maintenanceMode)
                return;

            MaintenanceMode = maintenanceMode;
            _maintenanceModeChanged = true;
        }

        private static string ReadDeviceGuid()
        {
            var devicePath = GetDeviceGuidPath();
            var deviceGuid = AtomicBlobStore.TryReadBlob(devicePath);
            if (deviceGuid == null)
                return null;

            using var reader = new IOReader(deviceGuid);

            var fileVersion = reader.ReadInt32();
            if (fileVersion == DeviceGuidFileVersion)
                return reader.ReadString(0x80);

            // Log Warning "Found incompatible DeviceGuid file version {fileVersion}, expected {DeviceGuidFileVersion}"
            return null;
        }

        private static void SetDeviceGuid(string deviceGuid)
        {
            DeviceGuid = deviceGuid;

            using var writer = new IOWriter();

            writer.WriteInt32(DeviceGuidFileVersion);
            writer.WriteString(deviceGuid);

            var devicePath = GetDeviceGuidPath();
            var blob = writer.ConvertToStream().ToArray();
            var wasWritten = AtomicBlobStore.TryWriteBlob(devicePath, blob);
            if (!wasWritten)
                ; // Log Error "Storing DeviceGuid as blob {devicePath} failed"
        }

        private static string GetDeviceGuidPath()
        {
            return Path.Combine(PersistentDataPath, "MetaplayDeviceGuid.dat");
        }

        private class MetaplayConnectionSDKHook : IMetaplayConnectionSDKHook
        {
            public void OnCurrentCdnAddressUpdated(MetaplayCdnAddress currentAddress)
            {
                CdnAddress = currentAddress;
            }

            public void OnScheduledMaintenanceModeUpdated(MaintenanceModeState maintenanceMode)
            {
                SetMaintenanceMode(maintenanceMode);
            }

            public void OnSessionStarted(SessionProtocol.SessionStartSuccess sessionStart)
            {
                ActiveExperiments.Clear();

                if (sessionStart.ActiveExperiments != null)
                {
                    foreach (var activeExp in sessionStart.ActiveExperiments)
                    {
                        var memStatus = ExperimentMembershipStatus.FromSessionInfo(activeExp);
                        ActiveExperiments.Add(activeExp.ExperimentId, memStatus);
                    }
                }

                if (!string.IsNullOrEmpty(sessionStart.CorrectedDeviceGuid))
                    SetDeviceGuid(sessionStart.CorrectedDeviceGuid);

                var versionSet = new HashSet<ContentHash>(Connection.SessionStartResources.GameConfigBaselineVersions.Values);
                UpkeepConfigCacheDirectory("SharedGameConfig", versionSet);

                versionSet = new HashSet<ContentHash>(Connection.SessionStartResources.GameConfigPatchVersions.Values);
                UpkeepConfigCacheDirectory("SharedGameConfigPatches", versionSet);

                LocalizationManager.OnSessionStarted(sessionStart);
                //SocialAuthentication.OnSessionStarted();
            }

            public string GetDeviceGuid()
            {
                return DeviceGuid;
            }

            private static void UpkeepConfigCacheDirectory(string cacheDirName, HashSet<ContentHash> retainedVersions)
            {
                var path = Path.Combine(DownloadCachePath, cacheDirName);
                var files = Directory.GetFiles(path);

                if (files.Length <= 9)
                    return;

                for (var i = 0; i < files.Length; i++)
                {
                    var fileName = Path.GetFileName(files[i]);
                    if (!ContentHash.TryParseString(fileName, out var fileHash))
                        continue;

                    if (!retainedVersions.Contains(fileHash))
                        continue;

                    // Log info "Pruning cached {cacheDirName} version {fileHash}"
                    File.Delete(files[i]);
                }
            }
        }
    }
}

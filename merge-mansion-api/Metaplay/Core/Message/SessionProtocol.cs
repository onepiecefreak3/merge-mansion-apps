using System.Collections.Generic;
using Metaplay.Core.Client;
using Metaplay.Core.Localization;
using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity.Messages;
using Metaplay.Core.Player;
using Metaplay.Core.Serialization;
using Metaplay.Core.Session;

namespace Metaplay.Core.Message
{
    public static class SessionProtocol
    {
        [MetaSerializable]
        public class SessionResourceCorrection
        {
            [MetaMember(1, 0)]
            public Dictionary<ClientSlot, ConfigArchiveUpdateInfo> ConfigUpdates; // 0x10
            [MetaMember(2, 0)]
            public Dictionary<ClientSlot, ConfigPatchesUpdateInfo> PatchUpdates; // 0x18
            [MetaMember(3, 0)]
            public LanguageUpdateInfo? LanguageUpdate; // 0x20

            public SessionResourceCorrection()
            {
                ConfigUpdates = new Dictionary<ClientSlot, ConfigArchiveUpdateInfo>();
                PatchUpdates = new Dictionary<ClientSlot, ConfigPatchesUpdateInfo>();
                LanguageUpdate = null;
            }

            public bool HasAnyCorrection()
            {
                if (ConfigUpdates.Count >= 1)
                    return true;

                if (PatchUpdates.Count >= 1)
                    return true;

                return LanguageUpdate.HasValue;
            }

            public static SessionResourceCorrection Combine(SessionResourceCorrection a, SessionResourceCorrection b)
            {
                var correction = new SessionResourceCorrection();

                foreach (var update in a.ConfigUpdates)
                    correction.ConfigUpdates.Add(update.Key, update.Value);
                foreach (var update in b.ConfigUpdates)
                    correction.ConfigUpdates.Add(update.Key, update.Value);

                foreach (var update in a.PatchUpdates)
                    correction.PatchUpdates.Add(update.Key, update.Value);
                foreach (var update in b.PatchUpdates)
                    correction.PatchUpdates.Add(update.Key, update.Value);

                correction.LanguageUpdate = a.LanguageUpdate ?? b.LanguageUpdate;

                return correction;
            }

            public struct ConfigArchiveUpdateInfo
            {
                // Fields
                [MetaMember(1, 0)]
                public ContentHash SharedGameConfigVersion; // 0x0
                [MetaMember(2, 0)]
                public string UrlSuffix; // 0x10

                public ConfigArchiveUpdateInfo(ContentHash sharedGameConfigVersion, string urlSuffix)
                {
                    SharedGameConfigVersion = sharedGameConfigVersion;
                    UrlSuffix = urlSuffix;
                }
            }

            public struct ConfigPatchesUpdateInfo
            {
                // Fields
                [MetaMember(1, 0)]
                public ContentHash PatchesVersion; // 0x0

                public ConfigPatchesUpdateInfo(ContentHash patchesVersion)
                {
                    PatchesVersion = patchesVersion;
                }
            }

            public struct LanguageUpdateInfo
            {
                // HINT: MetaMembers do not exist in original code. It's possible that [MetaImplicitMembersRange(1, 100)] implicitly denotes members a tagId to deserialize to
                [MetaMember(1, 0)]
                public LanguageId ActiveLanguage; // 0x0
                [MetaMember(2, 0)]
                public ContentHash LocalizationVersion; // 0x8

                public LanguageUpdateInfo(LanguageId activeLanguage, ContentHash localizationVersion)
                {
                    ActiveLanguage = activeLanguage;
                    LocalizationVersion = localizationVersion;
                }
            }
        }

        [MetaSerializable]

        public class InitialPlayerState
        {
            [MetaMember(1, 0)]
            public MetaSerialized<IPlayerModelBase> PlayerModel { get; set; } // 0x10
            [MetaMember(2, 0)]
            public int CurrentOperation { get; set; } // 0x20

            private InitialPlayerState() { }

            public InitialPlayerState(MetaSerialized<IPlayerModelBase> playerModel, int currentOperation)
            {
                PlayerModel = playerModel;
                CurrentOperation = currentOperation;
            }
        }

        public struct SessionResourceProposal
        {
            [MetaMember(1, 0)]
            public Dictionary<ClientSlot, ContentHash> ConfigVersions { get; set; }  // 0x0
            [MetaMember(2, 0)]
            public Dictionary<ClientSlot, ContentHash> PatchVersions { get; set; }   // 0x8
            [MetaMember(10, 0)]
            public LanguageId ClientActiveLanguage { get; set; }    // 0x10
            [MetaMember(11, 0)]
            public ContentHash ClientLocalizationVersion { get; set; }  // 0x18

            public SessionResourceProposal(Dictionary<ClientSlot, ContentHash> configVersions,
                Dictionary<ClientSlot, ContentHash> patchVersions, LanguageId clientActiveLanguage,
                ContentHash clientLocalizationVersion)
            {
                ConfigVersions = configVersions;
                PatchVersions = patchVersions;
                ClientActiveLanguage = clientActiveLanguage;
                ClientLocalizationVersion = clientLocalizationVersion;
            }
        }

        public struct ServerOptions
        {
            [MetaMember(1, 0)]
            public int PushUploadPercentageSessionStartFailedIncidentReport; // 0x0
            [MetaMember(2, 0)]
            public bool EnableWireCompression; // 0x4
            [MetaMember(3, 0)]
            public MetaDuration DeletionRequestSafetyDelay; // 0x8
            [MetaMember(4, 0)]
            public string GameServerGooglePlaySignInOAuthClientId; // 0x10
            [MetaMember(5, 0)]
            public string ImmutableXLinkApiUrl; // 0x18
            [MetaMember(6, 0)]
            public string GameEnvironment; // 0x20

            public ServerOptions(int pushUploadPercentageSessionStartFailedIncidentReport, bool enableWireCompression, MetaDuration deletionRequestSafetyDelay, string gameServerGooglePlaySignInOAuthClientId, string immutableXLinkApiUrl, string gameEnvironment)
            {
                PushUploadPercentageSessionStartFailedIncidentReport = pushUploadPercentageSessionStartFailedIncidentReport;
                EnableWireCompression = enableWireCompression;
                DeletionRequestSafetyDelay = deletionRequestSafetyDelay;
                GameServerGooglePlaySignInOAuthClientId = gameServerGooglePlaySignInOAuthClientId;
                ImmutableXLinkApiUrl = immutableXLinkApiUrl;
                GameEnvironment = gameEnvironment;
            }
        }

        [MetaMessage(16, MessageDirection.ClientToServer, true)]
        public class SessionStartRequest : MetaMessage
        {
            [MetaMember(1, 0)]
            public int QueryId { get; set; } // 0x10
            [MetaMember(2, 0)]
            public string DeviceGuid { get; set; } // 0x18
            [MetaMember(3, 0)]
            public string DeviceModel { get; set; } // 0x20
            [MetaMember(4, 0)]
            public PlayerTimeZoneInfo TimeZoneInfo { get; set; } // 0x28
            [MetaMember(5, 0)]
            public SessionProtocol.SessionResourceProposal ResourceProposal { get; set; } // 0x30
            [MetaMember(6, 0)]
            public bool IsDryRun { get; set; } // 0x58
            [MetaMember(7, 0)]
            public SessionProtocol.ISessionStartRequestGamePayload GamePayload { get; set; } // 0x60
            [MetaMember(8, 0)]
            public CompressionAlgorithmSet SupportedArchiveCompressions { get; set; } // 0x68
            [MetaMember(9, 0)]
            public ClientAppPauseStatus ClientAppPauseStatus { get; set; } // 0x6C

            private SessionStartRequest() { }

            public SessionStartRequest(int queryId, string deviceGuid, string deviceModel, PlayerTimeZoneInfo timeZoneInfo,
                SessionResourceProposal resourceProposal, bool isDryRun,
                ISessionStartRequestGamePayload gamePayload,
                CompressionAlgorithmSet supportedArchiveCompressions, ClientAppPauseStatus clientAppPauseStatus)
            {
                QueryId = queryId;
                DeviceGuid = deviceGuid;
                DeviceModel = deviceModel;
                TimeZoneInfo = timeZoneInfo;
                ResourceProposal = resourceProposal;
                IsDryRun = isDryRun;
                GamePayload = gamePayload;
                SupportedArchiveCompressions = supportedArchiveCompressions;
                ClientAppPauseStatus = clientAppPauseStatus;
            }
        }

        [MetaMessage(17, MessageDirection.ServerToClient, true)]
        public class SessionStartSuccess : MetaMessage
        {
            [MetaMember(1, 0)]
            public int QueryId { get; set; } // 0x10
            [MetaMember(2, 0)]
            public int LogicVersion { get; set; } // 0x14
            [MetaMember(3, 0)]
            public SessionToken SessionToken { get; set; } // 0x18
            [MetaMember(4, 0)]
            public ScheduledMaintenanceMode ScheduledMaintenanceMode { get; set; } // 0x20
            [MetaMember(5, 0)]
            public EntityId PlayerId { get; set; } // 0x28
            [MetaMember(6, 0)]
            public InitialPlayerState PlayerState { get; set; } // 0x30
            [MetaMember(8, 0)]
            public Dictionary<LanguageId, ContentHash> LocalizationVersions { get; set; } // 0x38
            [MetaMember(9, 0)]
            public List<EntityActiveExperiment> ActiveExperiments { get; set; } // 0x40
            [MetaMember(10, 0)]
            public bool DeveloperMaintenanceBypass { get; set; } // 0x48
            [MetaMember(11, 0)]
            public List<EntityInitialState> EntityStates { get; set; } // 0x50
            [MetaMember(12, 0)]
            public ISessionStartSuccessGamePayload GamePayload { get; set; } // 0x58
            [MetaMember(14, 0)]
            public string CorrectedDeviceGuid { get; set; } // 0x60

            private SessionStartSuccess() { }

            public SessionStartSuccess(int queryId, int logicVersion, SessionToken sessionToken,
                ScheduledMaintenanceMode scheduledMaintenanceMode, EntityId playerId,
                InitialPlayerState playerState,
                Dictionary<LanguageId, ContentHash> localizationVersions,
                List<EntityActiveExperiment> activeExperiments, bool developerMaintenanceBypass,
                List<EntityInitialState> entityStates, ISessionStartSuccessGamePayload gamePayload,
                string correctDeviceGuid)
            {
                QueryId = queryId;
                LogicVersion = logicVersion;
                SessionToken = sessionToken;
                ScheduledMaintenanceMode = scheduledMaintenanceMode;
                PlayerId = playerId;
                PlayerState = playerState;
                LocalizationVersions = localizationVersions;
                ActiveExperiments = activeExperiments;
                DeveloperMaintenanceBypass = developerMaintenanceBypass;
                EntityStates = entityStates;
                GamePayload = gamePayload;
                CorrectedDeviceGuid = correctDeviceGuid;
            }
        }

        [MetaMessage(18, MessageDirection.ServerToClient, true)]
        public class SessionStartFailure : MetaMessage
        {
            [MetaMember(1, 0)]
            public int QueryId { get; set; } // 0x10
            [MetaMember(2, 0)]
            public ReasonCode Reason { get; set; } // 0x14
            [MetaMember(3, 0)]
            public SessionResourceCorrection ResourceCorrection { get; set; } // 0x18
            [MetaMember(4, 0)]
            public string DebugOnlyErrorMessage { get; set; } // 0x20

            private SessionStartFailure() { }

            public SessionStartFailure(int queryId, ReasonCode reason, SessionResourceCorrection resourceCorrection,
                string debugOnlyErrorMessage)
            {
                QueryId = queryId;
                Reason = reason;
                ResourceCorrection = resourceCorrection;
                DebugOnlyErrorMessage = debugOnlyErrorMessage;
            }

            public enum ReasonCode
            {
                InternalError = 0,
                DryRun = 1,
                ResourceCorrection = 2,
                Banned = 3,
                PlayerDeserializationFailure = 4,
                WrongAuthenticationPlatform = 5
            }
        }

        [MetaMessage(19, MessageDirection.ClientToServer, true)]
        public class SessionResumeRequest : MetaMessage
        {
            [MetaMember(1, 0)]
            public SessionResumptionInfo SessionToResume { get; set; } // 0x10

            private SessionResumeRequest() { }

            public SessionResumeRequest(SessionResumptionInfo sessionToResume)
            {
                SessionToResume = sessionToResume;
            }
        }

        [MetaMessage(20, MessageDirection.ServerToClient, true)]
        public class SessionResumeSuccess : MetaMessage
        {
            [MetaMember(1, 0)]
            public SessionAcknowledgement ServerSessionAcknowledgement { get; set; } // 0x10
            [MetaMember(2, 0)]
            public SessionToken SessionToken { get; set; } // 0x18
            [MetaMember(3, 0)]
            public ScheduledMaintenanceMode ScheduledMaintenanceMode { get; set; } // 0x20

            private SessionResumeSuccess() { }

            public SessionResumeSuccess(SessionAcknowledgement serverSessionAcknowledgement, SessionToken sessionToken,
                ScheduledMaintenanceMode scheduledMaintenanceMode)
            {
                ServerSessionAcknowledgement = serverSessionAcknowledgement;
                SessionToken = sessionToken;
                ScheduledMaintenanceMode = scheduledMaintenanceMode;
            }
        }

        [MetaMessage(21, MessageDirection.ServerToClient, true)]
        public class SessionResumeFailure : MetaMessage
        { }

        [MetaMessage(43, MessageDirection.ClientToServer, true)]
        public class SessionStartAbortReasonTrailer : MetaMessage
        {
            [MetaMember(1, 0)]
            public string IncidentId { get; set; }
            [MetaMember(2, 0)]
            public byte[] Incident { get; set; }

            private SessionStartAbortReasonTrailer() { }

            public SessionStartAbortReasonTrailer(string incidentId, byte[] incident)
            {
                IncidentId = incidentId;
                Incident = incident;
            }
        }

        public interface ISessionStartRequestGamePayload
        { }
    }
}

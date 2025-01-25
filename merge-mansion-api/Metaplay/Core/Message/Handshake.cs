using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;
using Metaplay.Core.Session;

namespace Metaplay.Core.Message
{
    public static class Handshake
    {
        [MetaMessage(4, (MessageDirection)2, true)]
        public class ServerHello : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string ServerVersion { get; set; } // 0x10

            [MetaMember(2, (MetaMemberFlags)0)]
            public string BuildNumber { get; set; } // 0x18

            [MetaMember(3, (MetaMemberFlags)0)]
            public uint FullProtocolHash { get; set; } // 0x20

            [MetaMember(4, (MetaMemberFlags)0)]
            public string CommitId { get; set; } // 0x28

            private ServerHello()
            {
            }

            public ServerHello(string serverVersion, string buildNumber, uint fullProtocolHash, string commitId)
            {
                ServerVersion = serverVersion;
                BuildNumber = buildNumber;
                FullProtocolHash = fullProtocolHash;
                CommitId = commitId;
            }

            [MetaMember(5, (MetaMemberFlags)0)]
            public string ProjectName { get; set; }

            public ServerHello(string serverVersion, string buildNumber, uint fullProtocolHash, string commitId, string projectName)
            {
            }
        }

        [MessageRoutingRuleProtocol]
        [MetaMessage(5, (MessageDirection)1, true)]
        public class ClientHello : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string ClientVersion { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string BuildNumber { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public MetaVersionRange SupportedLogicVersions { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public uint FullProtocolHash { get; set; }

            [MetaMember(5, (MetaMemberFlags)0)]
            public string CommitId { get; set; }
            public DateTime Timestamp { get; set; }

            [MetaMember(7, (MetaMemberFlags)0)]
            public uint AppLaunchId { get; set; }

            [MetaMember(8, (MetaMemberFlags)0)]
            public uint ClientSessionNonce { get; set; }

            [MetaMember(9, (MetaMemberFlags)0)]
            public uint ClientSessionConnectionNdx { get; set; }

            [MetaMember(10, (MetaMemberFlags)0)]
            public ClientPlatform Platform { get; set; }

            [MetaMember(11, (MetaMemberFlags)0)]
            public int LoginProtocolVersion { get; set; }

            private ClientHello()
            {
            }

            public ClientHello(string clientVersion, string buildNumber, MetaVersionRange supportedLogicVersions, uint fullProtocolHash, string commitId, DateTime timestamp, uint appLaunchId, uint clientSessionNonce, uint clientSessionConnectionNdx, ClientPlatform platform, int loginProtocolVersion)
            {
                ClientVersion = clientVersion;
                BuildNumber = buildNumber;
                SupportedLogicVersions = supportedLogicVersions;
                FullProtocolHash = fullProtocolHash;
                CommitId = commitId;
                Timestamp = timestamp;
                AppLaunchId = appLaunchId;
                ClientSessionNonce = clientSessionNonce;
                ClientSessionConnectionNdx = clientSessionConnectionNdx;
                Platform = platform;
                LoginProtocolVersion = loginProtocolVersion;
            }

            public ClientHello(string clientVersion, string buildNumber, int clientLogicVersion, uint fullProtocolHash, string commitId, MetaTime timestamp, uint appLaunchId, uint clientSessionNonce, uint clientSessionConnectionNdx, ClientPlatform platform, int loginProtocolVersion)
            {
            }

            [MetaMember(12, (MetaMemberFlags)0)]
            public string TargetHostname { get; set; }
            public int ClientLogicVersion { get; }

            public ClientHello(string clientVersion, string buildNumber, int clientLogicVersion, uint fullProtocolHash, string commitId, MetaTime timestamp, uint appLaunchId, uint clientSessionNonce, uint clientSessionConnectionNdx, ClientPlatform platform, int loginProtocolVersion, string targetHostname)
            {
            }

            [MetaMember(6, (MetaMemberFlags)0)]
            private MetaTime _timestamp;
            public ClientHello(string clientVersion, string buildNumber, int clientLogicVersion, uint fullProtocolHash, string commitId, DateTime timestamp, uint appLaunchId, uint clientSessionNonce, uint clientSessionConnectionNdx, ClientPlatform platform, int loginProtocolVersion, string targetHostname)
            {
            }
        }

        [MetaMessage(6, (MessageDirection)1, true)]
        [MessageRoutingRuleProtocol]
        public class ClientAbandon : MetaMessage
        {
            public DateTime ConnectionStartedAt { get; set; }
            public DateTime ConnectionAbandonedAt { get; set; }
            public DateTime AbandonedCompletedAt { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public Handshake.ClientAbandon.AbandonSource Source { get; set; }

            public ClientAbandon(DateTime connectionStartedAt, DateTime connectionAbandonedAt, DateTime abandonedCompletedAt, AbandonSource source)
            {
                ConnectionStartedAt = connectionStartedAt;
                ConnectionAbandonedAt = connectionAbandonedAt;
                AbandonedCompletedAt = abandonedCompletedAt;
                Source = source;
            }

            [MetaSerializable]
            public enum AbandonSource
            {
                PrimaryConnection = 0,
                NetworkProbe = 1
            }

            private ClientAbandon()
            {
            }

            [PrettyPrint((PrettyPrintFlag)8)]
            [MetaMember(1, (MetaMemberFlags)0)]
            private MetaTime _connectionStartedAt;
            [PrettyPrint((PrettyPrintFlag)8)]
            [MetaMember(2, (MetaMemberFlags)0)]
            private MetaTime _connectionAbandonedAt;
            [MetaMember(3, (MetaMemberFlags)0)]
            [PrettyPrint((PrettyPrintFlag)8)]
            private MetaTime _abandonedCompletedAt;
        }

        [MessageRoutingRuleProtocol]
        [MetaMessage(7, (MessageDirection)1, true)]
        public class DeviceLoginRequest : Handshake.LoginRequest
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string DeviceId { get; set; } // 0x30

            [MetaMember(2, (MetaMemberFlags)0)]
            [Sensitive]
            public string AuthToken { get; set; } // 0x38

            private DeviceLoginRequest()
            {
            }

            public DeviceLoginRequest(string deviceId, string authToken, EntityId playerId, bool isBot, LoginDebugDiagnostics debugDiagnostics, ILoginRequestGamePayload gamePayload) : base(playerId, isBot, debugDiagnostics, gamePayload)
            {
                DeviceId = deviceId;
                AuthToken = authToken;
            }
        }

        [MetaMessage(8, (MessageDirection)2, true)]
        public class LoginSuccessResponse : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public EntityId LoggedInPlayerId { get; set; }

            private LoginSuccessResponse()
            {
            }

            public LoginSuccessResponse(EntityId loggedInPlayerId)
            {
            }
        }

        [MetaMessage(13, (MessageDirection)2, true)]
        public class LogicVersionMismatch : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaVersionRange ServerAcceptedLogicVersions { get; set; } // 0x10

            private LogicVersionMismatch()
            {
            }

            public LogicVersionMismatch(MetaVersionRange serverAcceptedLogicVersions)
            {
                ServerAcceptedLogicVersions = serverAcceptedLogicVersions;
            }
        }

        [MetaMessage(14, (MessageDirection)2, true)]
        public class RedirectToServer : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public ServerEndpoint RedirectToEndpoint { get; set; } // 0x10

            private RedirectToServer()
            {
            }

            public RedirectToServer(ServerEndpoint redirectToEndpoint)
            {
                RedirectToEndpoint = redirectToEndpoint;
            }
        }

        [MessageRoutingRuleProtocol]
        [MetaMessage(31, (MessageDirection)1, true)]
        public class SocialAuthenticationLoginRequest : Handshake.LoginRequest
        {
            [MetaMember(100, (MetaMemberFlags)0)]
            public SocialAuthenticationClaimBase Claim { get; set; } // 0x38

            private SocialAuthenticationLoginRequest()
            {
            }

            public SocialAuthenticationLoginRequest(SocialAuthenticationClaimBase claim, EntityId playerId, bool isBot, LoginDebugDiagnostics debugDiagnostics, ILoginRequestGamePayload gamePayload) : base(playerId, isBot, debugDiagnostics, gamePayload)
            {
                Claim = claim;
            }
        }

        [MetaMessage(32, MessageDirection.ClientToServer, true)]
        public class SocialAuthenticationLoginFailure : MetaMessage
        {
            public static SocialAuthenticationLoginFailure Instance = new SocialAuthenticationLoginFailure();
        }

        [MetaMessage(88, MessageDirection.ClientToServer, true)]
        public class OngoingMaintenance : MetaMessage
        {
            public static OngoingMaintenance Instance = new OngoingMaintenance();
        }

        [MetaMessage(89, MessageDirection.ClientToServer, false)]
        public class OperationStillOngoing : MetaMessage
        {
            public static OperationStillOngoing Instance = new OperationStillOngoing();
        }

        [MetaMessage(90, (MessageDirection)2, false)]
        public class ClientHelloAccepted : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public Handshake.ServerOptions ServerOptions { get; set; }

            private ClientHelloAccepted()
            {
            }

            public ClientHelloAccepted(Handshake.ServerOptions serverOptions)
            {
            }
        }

        [MetaMessage(91, (MessageDirection)2, true)]
        public class LoginProtocolVersionMismatch : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public int ServerAcceptedProtocolVersion { get; set; }

            private LoginProtocolVersionMismatch()
            {
            }

            public LoginProtocolVersionMismatch(int serverAcceptedProtocolVersion)
            {
            }
        }

        public abstract class LoginRequest : MetaMessage
        {
            [MetaMember(3, (MetaMemberFlags)0)]
            public EntityId PlayerIdHint { get; set; } // 0x10

            [MetaMember(4, (MetaMemberFlags)0)]
            public bool IsBot { get; set; } // 0x18

            [MetaMember(5, (MetaMemberFlags)0)]
            public LoginDebugDiagnostics DebugDiagnostics { get; set; } // 0x20

            [MetaMember(6, (MetaMemberFlags)0)]
            public Handshake.ILoginRequestGamePayload GamePayload { get; set; } // 0x28

            protected LoginRequest()
            {
            }

            public LoginRequest(EntityId playerIdHint, bool isBot, LoginDebugDiagnostics debugDiagnostics, ILoginRequestGamePayload gamePayload)
            {
                PlayerIdHint = playerIdHint;
                IsBot = isBot;
                DebugDiagnostics = debugDiagnostics;
                GamePayload = gamePayload;
            }
        }

        public struct ConnectionOptions
        {
            [MetaMember(1, 0)]
            public int PushUploadPercentageSessionStartFailedIncidentReport; // 0x0
            [MetaMember(2, 0)]
            public bool EnableWireCompression; // 0x4
            public ConnectionOptions(int pushUploadPercentageSessionStartFailedIncidentReport, bool enableWireCompression)
            {
                PushUploadPercentageSessionStartFailedIncidentReport = pushUploadPercentageSessionStartFailedIncidentReport;
                EnableWireCompression = enableWireCompression;
            }
        }

        [MetaBlockedMembers(new int[] { 7, 8 })]
        [MetaSerializable]
        public struct ServerOptions
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public int PushUploadPercentageSessionStartFailedIncidentReport; // 0x0
            [MetaMember(2, (MetaMemberFlags)0)]
            public bool EnableWireCompression; // 0x4
            [MetaMember(3, (MetaMemberFlags)0)]
            public MetaDuration DeletionRequestSafetyDelay; // 0x8
            [MetaMember(4, (MetaMemberFlags)0)]
            public string GameServerGooglePlaySignInOAuthClientId; // 0x10
            [MetaMember(5, (MetaMemberFlags)0)]
            public string ImmutableXLinkApiUrl; // 0x18
            [MetaMember(6, (MetaMemberFlags)0)]
            public string GameEnvironment; // 0x20
            [MetaMember(100, (MetaMemberFlags)0)]
            public int ClientTosVersion;
            [MetaMember(9, (MetaMemberFlags)0)]
            public MetaDuration GameTimeOffset;
        }

        [MetaSerializable]
        public interface ILoginRequestGamePayload
        {
        }

        [MetaMessage(93, (MessageDirection)2, true)]
        public class CreateGuestAccountResponse : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public EntityId PlayerId { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string DeviceId { get; set; }

            [Sensitive]
            [MetaMember(3, (MetaMemberFlags)0)]
            public string AuthToken { get; set; }

            private CreateGuestAccountResponse()
            {
            }

            public CreateGuestAccountResponse(EntityId playerId, string deviceId, string authToken)
            {
            }
        }

        [MetaMessage(19, (MessageDirection)1, true)]
        [MessageRoutingRuleProtocol]
        public class LoginAndResumeSessionRequest : MetaMessage
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public EntityId ClaimedPlayerId { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public SessionResumptionInfo SessionToResume { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            [Sensitive]
            public byte[] ResumptionToken { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public LoginDebugDiagnostics DebugDiagnostics { get; set; }

            [MetaMember(5, (MetaMemberFlags)0)]
            public Handshake.ILoginRequestGamePayload GamePayload { get; set; }

            private LoginAndResumeSessionRequest()
            {
            }

            public LoginAndResumeSessionRequest(EntityId claimedPlayerId, SessionResumptionInfo sessionToResume, byte[] resumptionToken, LoginDebugDiagnostics debugDiagnostics, Handshake.ILoginRequestGamePayload gamePayload)
            {
            }
        }

        [MetaMessage(32, (MessageDirection)1, true)]
        [MessageRoutingRuleProtocol]
        public class DualSocialAuthenticationLoginRequest : Handshake.LoginRequest
        {
            [MetaMember(100, (MetaMemberFlags)0)]
            public SocialAuthenticationClaimBase Claim { get; set; }

            [MetaMember(101, (MetaMemberFlags)0)]
            public string DeviceId { get; set; }

            [MetaMember(102, (MetaMemberFlags)0)]
            [Sensitive]
            public string AuthToken { get; set; }

            private DualSocialAuthenticationLoginRequest()
            {
            }

            public DualSocialAuthenticationLoginRequest(EntityId playerIdHint, bool isBot, LoginDebugDiagnostics debugDiagnostics, Handshake.ILoginRequestGamePayload gamePayload, SocialAuthenticationClaimBase claim, string deviceId, string authToken)
            {
            }
        }
    }
}
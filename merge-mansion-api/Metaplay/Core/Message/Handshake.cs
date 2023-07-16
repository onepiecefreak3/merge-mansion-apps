using System.Runtime.CompilerServices;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
    public static class Handshake
    {
        [MetaMessage(4, MessageDirection.ServerToClient, true)]
        public class ServerHello : MetaMessage
        {
            // Properties
            [MetaMember(1, 0)]
            public string ServerVersion { get; set; } // 0x10
            [MetaMember(2, 0)]
            public string BuildNumber { get; set; } // 0x18
            [MetaMember(3, 0)]
            public uint FullProtocolHash { get; set; } // 0x20
            [MetaMember(4, 0)]
            public string CommitId { get; set; } // 0x28

            private ServerHello() { }

            public ServerHello(string serverVersion, string buildNumber, uint fullProtocolHash, string commitId)
            {
                ServerVersion = serverVersion;
                BuildNumber = buildNumber;
                FullProtocolHash = fullProtocolHash;
                CommitId = commitId;
            }
        }

        [MetaMessage(5, MessageDirection.ClientToServer, true)]
        public class ClientHello : MetaMessage
        {
            [MetaMember(1, 0)]
            public string ClientVersion { get; set; }
            [MetaMember(2, 0)]
            public string BuildNumber { get; set; }
            [MetaMember(3, 0)]
            public MetaVersionRange SupportedLogicVersions { get; set; }
            [MetaMember(4, 0)]
            public uint FullProtocolHash { get; set; }
            [MetaMember(5, 0)]
            public string CommitId { get; set; }
            [MetaMember(6, 0)]
            public MetaTime Timestamp { get; set; }
            [MetaMember(7, 0)]
            public uint AppLaunchId { get; set; }
            [MetaMember(8, 0)]
            public uint ClientSessionNonce { get; set; }
            [MetaMember(9, 0)]
            public uint ClientSessionConnectionNdx { get; set; }
            [MetaMember(10, 0)]
            public ClientPlatform Platform { get; set; }
            [MetaMember(11, 0)]
            public int LoginProtocolVersion { get; set; }

            private ClientHello() { }

            public ClientHello(string clientVersion, string buildNumber, MetaVersionRange supportedLogicVersions,
                uint fullProtocolHash, string commitId, MetaTime timestamp, uint appLaunchId, uint clientSessionNonce,
                uint clientSessionConnectionNdx, ClientPlatform platform, int loginProtocolVersion)
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
        }

        [MetaMessage(6, MessageDirection.ClientToServer, true)]
        public class ClientAbandon : MetaMessage
        {
            [MetaMember(1, 0)]
            public MetaTime ConnectionStartedAt { get; set; }
            [MetaMember(2, 0)]
            public MetaTime ConnectionAbandonedAt { get; set; }
            [MetaMember(3, 0)]
            public MetaTime AbandonedCompletedAt { get; set; }
            [MetaMember(4, 0)]
            public AbandonSource Source { get; set; }

            public ClientAbandon(MetaTime connectionStartedAt, MetaTime connectionAbandonedAt, MetaTime abandonedCompletedAt, AbandonSource source)
            {
                ConnectionStartedAt = connectionStartedAt;
                ConnectionAbandonedAt = connectionAbandonedAt;
                AbandonedCompletedAt = abandonedCompletedAt;
                Source = source;
            }

            public enum AbandonSource
            {
                PrimaryConnection = 0,
                NetworkProbe = 1
            }
        }

        [MetaMessage(7, MessageDirection.ClientToServer, true)]
        public sealed class DeviceLoginRequest : LoginRequest
        {
            // Properties
            [MetaMember(1, 0)]
            public string DeviceId { get; set; } // 0x30
            [MetaMember(2, 0)]
            public string AuthToken { get; set; } // 0x38
            public override bool IsCreateAccountRequest => string.IsNullOrEmpty(DeviceId) && string.IsNullOrEmpty(AuthToken);

            private DeviceLoginRequest() { }

            public DeviceLoginRequest(string deviceId, string authToken, EntityId playerId, bool isBot,
                LoginDebugDiagnostics debugDiagnostics, ILoginRequestGamePayload gamePayload) : base(playerId, isBot, debugDiagnostics, gamePayload)
            {
                DeviceId = deviceId;
                AuthToken = authToken;
            }
        }

        [MetaMessage(8, MessageDirection.ServerToClient, true)]
        public class LoginResponse : MetaMessage
        {
            [MetaMember(1, 0)]
            public EntityId PlayerId { get; set; } // 0x10
            [MetaMember(2, 0)]
            public string DeviceId { get; set; } // 0x18
            [MetaMember(3, 0)]
            public string AuthToken { get; set; } // 0x20
            [MetaMember(4, 0)]
            public ConnectionOptions Options { get; set; } // 0x28

            private LoginResponse() { }

            public LoginResponse(EntityId playerId, string deviceId, string authToken, ConnectionOptions options)
            {
                PlayerId = playerId;
                DeviceId = deviceId;
                AuthToken = authToken;
                Options = options;
            }
        }

        [MetaMessage(13, MessageDirection.ClientToServer, true)]
        public class LogicVersionMismatch : MetaMessage
        {
            [MetaMember(1, 0)]
            public MetaVersionRange ServerAcceptedLogicVersions { get; set; } // 0x10

            private LogicVersionMismatch() { }

            public LogicVersionMismatch(MetaVersionRange serverAcceptedLogicVersions)
            {
                ServerAcceptedLogicVersions = serverAcceptedLogicVersions;
            }
        }

        [MetaMessage(14, MessageDirection.ClientToServer, true)]
        public class RedirectToServer : MetaMessage
        {
            [MetaMember(1, 0)]
            public ServerEndpoint RedirectToEndpoint { get; set; } // 0x10

            private RedirectToServer() { }

            public RedirectToServer(ServerEndpoint redirectToEndpoint)
            {
                RedirectToEndpoint = redirectToEndpoint;
            }
        }

        [MetaMessage(31, MessageDirection.ClientToServer, true)]
        public sealed class SocialAuthenticationLoginRequest : LoginRequest
        {
            [MetaMember(100, 0)]
            public SocialAuthenticationClaimBase Claim { get; set; } // 0x38
            public override bool IsCreateAccountRequest => false;

            private SocialAuthenticationLoginRequest() { }

            public SocialAuthenticationLoginRequest(SocialAuthenticationClaimBase claim, EntityId playerId,
                bool isBot, LoginDebugDiagnostics debugDiagnostics,
                ILoginRequestGamePayload gamePayload) : base(playerId, isBot, debugDiagnostics, gamePayload)
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

        [MetaMessage(90, MessageDirection.ServerToClient, false)]
        public class ClientHelloAccepted : MetaMessage
        {
            // Properties
            [MetaMember(1, 0)]
            public ServerOptions ServerOptions { get; set; }
        }

        [MetaMessage(91, MessageDirection.ServerToClient, true)]
        public class LoginProtocolVersionMismatch : MetaMessage
        {
            // Properties
            [MetaMember(1, 0)]
            public int ServerAcceptedProtocolVersion { get; set; }
        }

        public abstract class LoginRequest : MetaMessage
        {
            // Properties
            [MetaMember(3, 0)]
            public EntityId PlayerIdHint { get; set; } // 0x10
            [MetaMember(4, 0)]
            public bool IsBot { get; set; } // 0x18
            [MetaMember(5, 0)]
            public LoginDebugDiagnostics DebugDiagnostics { get; set; } // 0x20
            [MetaMember(6, 0)]
            public ILoginRequestGamePayload GamePayload { get; set; } // 0x28

            public abstract bool IsCreateAccountRequest { get; }

            protected LoginRequest() { }

            public LoginRequest(EntityId playerIdHint, bool isBot, LoginDebugDiagnostics debugDiagnostics,
                ILoginRequestGamePayload gamePayload)
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

            public ConnectionOptions(int pushUploadPercentageSessionStartFailedIncidentReport,
                bool enableWireCompression)
            {
                PushUploadPercentageSessionStartFailedIncidentReport =
                    pushUploadPercentageSessionStartFailedIncidentReport;
                EnableWireCompression = enableWireCompression;
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
        }

        public interface ILoginRequestGamePayload
        { }
    }
}

using System;
using Metaplay.Core;
using Metaplay.Core.Network;

namespace Metaplay.Unity.ConnectionStates
{
    public abstract class TerminalError : ConnectionState
    {
        public sealed override ConnectionStatus Status => ConnectionStatus.Error;

        protected TerminalError() { }

        public class Unknown : TerminalError
        {
            public readonly string DebugInfo; // 0x10

            public Unknown() { }

            public Unknown(string debugInfo)
            {
                DebugInfo = debugInfo;
            }
        }

        public class InvalidGameMagic : TerminalError
        {
            public uint Magic { get; }

            public InvalidGameMagic(uint magic)
            {
                Magic = magic;
            }
        }

        public class WireProtocolVersionMismatch : TerminalError
        {
            public int ClientProtocolVersion { get; }
            public int ServerProtocolVersion { get; }

            public WireProtocolVersionMismatch(int clientProtocolVersion, int serverProtocolVersion)
            {
                ClientProtocolVersion = clientProtocolVersion;
                ServerProtocolVersion = serverProtocolVersion;
            }
        }

        public class LogicVersionMismatch : TerminalError
        {
            public MetaVersionRange ClientSupportedLogicVersions { get; }
            public MetaVersionRange ServerAcceptedVersions { get; }

            public LogicVersionMismatch(MetaVersionRange clientSupportedLogicVersions, MetaVersionRange serverAcceptedVersions)
            {
                ClientSupportedLogicVersions = clientSupportedLogicVersions;
                ServerAcceptedVersions = serverAcceptedVersions;
            }
        }

        public class CommitIdMismatch : TerminalError
        {
            public string ClientCommitId { get; }
            public string ServerCommitId { get; }

            public CommitIdMismatch(string clientCommitId, string serverCommitId)
            {
                ClientCommitId = clientCommitId;
                ServerCommitId = serverCommitId;
            }
        }

        public class PlayerIsBanned : TerminalError
        { }

        public class WrongAuthenticationMethod : TerminalError
        { }

        public class SocialAuthenticationLoginFailed : TerminalError
        { }

        public class ServerPlayerDeserializationFailure : TerminalError
        {
            public readonly string Message; // 0x10

            public ServerPlayerDeserializationFailure(string message)
            {
                Message = message;
            }
        }

        public class WireFormatError : TerminalError
        {
            public readonly Exception Exception; // 0x10

            public WireFormatError(Exception exeption)
            {
                Exception = exeption;
            }
        }

        public class NoFreeDiskSpace : TerminalError
        { }

        public class InMaintenance : TerminalError
        { }

        public class NoNetworkConnectivity : TerminalError, IHasNetworkDiagnosticReport
        {
            public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; }
        }

        public class ClientSideConnectionError : TerminalError
        {
            public readonly Exception Exception; // 0x10
            
            public ClientSideConnectionError(Exception exception)
            {
                Exception = exception;
            }
        }
    }
}

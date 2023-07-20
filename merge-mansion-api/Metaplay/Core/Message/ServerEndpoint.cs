using System.Collections.Generic;
using System.Linq;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
    [MetaSerializable]
    public class ServerEndpoint
    {
        [MetaMember(1, 0)]
        public string ServerHost { get; set; } // 0x10
        [MetaMember(2, 0)]
        public int ServerPort { get; set; } // 0x18
        [MetaMember(3, 0)]
        public bool EnableTls { get; set; } // 0x1C
        [MetaMember(4, 0)]
        public string CdnBaseUrl { get; set; } // 0x20
        [MetaMember(5, 0)]
        private List<ServerGateway> BackupGatewaySpecs { get; set; } // 0x28

        public bool IsOfflineMode => string.IsNullOrEmpty(ServerHost);
        public ServerGateway PrimaryGateway => new ServerGateway(ServerHost, ServerPort, EnableTls);
        public IEnumerable<ServerGateway> BackupGateways => BackupGatewaySpecs.Select(x => new ServerGateway(string.IsNullOrEmpty(x.ServerHost) ? ServerHost : x.ServerHost, ServerPort, EnableTls));

        public ServerEndpoint() { }

        public ServerEndpoint(string serverHost, int serverPort, bool enableTls, string cdnBaseUrl)
        {
            ServerHost = serverHost;
            ServerPort = serverPort;
            EnableTls = enableTls;
            CdnBaseUrl = cdnBaseUrl;
        }

        public ServerEndpoint(string serverHost, int serverPort, bool enableTls, string cdnBaseUrl, List<ServerGateway> backupGateways)
        {
            ServerHost = serverHost;
            ServerPort = serverPort;
            EnableTls = enableTls;
            CdnBaseUrl = cdnBaseUrl;
            BackupGatewaySpecs = backupGateways;
        }

        public static bool operator ==(ServerEndpoint a, ServerEndpoint b) => a.ServerHost == b.ServerHost && a.ServerPort == b.ServerPort && a.EnableTls == b.EnableTls && a.CdnBaseUrl == b.CdnBaseUrl;
        public static bool operator !=(ServerEndpoint a, ServerEndpoint b) => a.ServerHost != b.ServerHost || a.ServerPort != b.ServerPort || a.EnableTls != b.EnableTls || a.CdnBaseUrl != b.CdnBaseUrl;

        public override bool Equals(object obj)
        {
            if (!(obj is ServerEndpoint seObj))
                return false;

            return this == seObj;
        }

        public override int GetHashCode()
        {
            return CdnBaseUrl.GetHashCode() + (EnableTls.GetHashCode() + (ServerPort.GetHashCode() + ServerHost.GetHashCode() * 0x705) * 0x1eef) * 0xd;
        }

        public override string ToString()
        {
            return $"ServerEndpoint({ServerHost}:{ServerPort}, tls={EnableTls}, cdn={CdnBaseUrl})";
        }
    }
}

using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
	public class ServerGateway
    {
        [MetaMember(1, 0)]
        public string ServerHost { get; set; } // 0x10
        [MetaMember(2, 0)]
        public int ServerPort { get; set; } // 0x18
        [MetaMember(3, 0)]
        public bool EnableTls { get; set; } // 0x1C

        public ServerGateway() { }

        public ServerGateway(string serverHost, int serverPort, bool enableTls)
        {
            ServerHost = serverHost;
            ServerPort = serverPort;
            EnableTls = enableTls;
        }
    }
}

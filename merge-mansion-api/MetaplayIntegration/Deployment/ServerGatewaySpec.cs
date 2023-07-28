using Metaplay.Core.Message;

namespace MetaplayIntegration.Deployment
{
    public class ServerGatewaySpec
    {
        public string Id; // 0x10
        public string ServerHost; // 0x18
        public int ServerPort; // 0x20

        public ServerGateway ToGateway(bool enableTls)
        {
            return new ServerGateway
            {
                ServerHost = ServerHost,
                ServerPort = ServerPort,
                EnableTls = enableTls
            };
        }
    }
}

using System.Collections.Generic;

namespace Metaplay.MetaplayIntegration.Deployment
{
    public class DeploymentSpec
    {
        public string Id; // 0x10
        public string ServerHost; // 0x28
        public int ServerPort; // 0x30
        public bool EnableTls; // 0x34
        public string CdnBaseUrl; // 0x38
        public List<ServerGatewaySpec> BackupGateways; // 0x48
        public bool UseFakePurchasing; // 0x50

        public bool IsOfflineMode => string.IsNullOrEmpty(ServerHost);
    }
}

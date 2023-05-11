using System;
using System.Collections.Generic;

namespace Metaplay.MetaplayIntegration.Deployment
{
    public class DeploymentConfig
    {
        private static DeploymentConfig instance; // 0x0

        public string SelectedSpecId; // 0x18
        public List<DeploymentSpec> Specs; // 0x20

        // TODO: Load resource Resources.Load<DeploymentConfig>("DeploymentConfig")
        public static DeploymentConfig Instance => instance ??= new DeploymentConfig
        {
            SelectedSpecId = "prod",
            Specs = new List<DeploymentSpec>
            {
                new DeploymentSpec
                {
                    Id = "prod",
                    ServerHost = "prod.p1.game5backend.com",
                    ServerPort = 9339,
                    EnableTls = true,
                    CdnBaseUrl = "https://prod-assets.p1.game5backend.com/",
                    BackupGateways = new List<ServerGatewaySpec>
                    {
                        new ServerGatewaySpec
                        {
                            Id = "alt-port-https",
                            ServerHost = null,
                            ServerPort = 443
                        },
                        new ServerGatewaySpec
                        {
                            Id = "alt-port-1863",
                            ServerHost = null,
                            ServerPort = 1863
                        },
                        new ServerGatewaySpec
                        {
                            Id = "alt-port-3724",
                            ServerHost = null,
                            ServerPort = 3724
                        },
                        new ServerGatewaySpec
                        {
                            Id = "alt-port-5061",
                            ServerHost = null,
                            ServerPort = 5061
                        }
                    }
                }
            }
        };

        public static DeploymentSpec Selected => Instance.Specs.Find(x => x.Id == Instance.SelectedSpecId) ??
                                                 throw new InvalidOperationException($"Selected DeploymentConfig '{Instance.SelectedSpecId}' does not exist!");
        public bool PersistOfflineState => false;
    }
}

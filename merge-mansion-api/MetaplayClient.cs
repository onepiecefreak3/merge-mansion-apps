using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Client;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Player;
using Metaplay.Metaplay.Unity;
using Metaplay.Metaplay.Unity.DefaultIntegration;
using Metaplay.MetaplayIntegration;
using Metaplay.MetaplayIntegration.Deployment;
using Metaplay.UnityEngine;

namespace Metaplay
{
    public class MetaplayClient : ISessionContextProvider
    {
        private static IMetaplayClientConnectionDelegate _connectionDelegate; // 0x28

        //public static PlayerClientContext PlayerContext { get; set; }

        private SessionProtocol.SessionStartSuccess _initialState; // 0x10
        private List<Action> _pendingSessionFuncs; // 0x18

        IPlayerClientContext ISessionContextProvider.PlayerContext { get; } //=> PlayerContext;
        public MetaplayClientStore ClientStore { get; }

        public MetaplayClient()
        {
            _pendingSessionFuncs = new List<Action>();

            MetaplaySDK.Start(new MetaplaySDKConfig
            {
                BuildVersion = new BuildVersion(Application.Version, "local", "7d56c04751bbe1f136a94a3c2e158c1dc0d027ee"),
                AutoCreateMetaplaySDKBehavior = false,
                ServerEndpoint = GetServerEndpoint(),
                ConnectionConfig = null,
                OfflineOptions = new MetaplayOfflineOptions { PersistState = DeploymentConfig.Instance.PersistOfflineState },
                ConnectionDelegate = _connectionDelegate = new GameConnectionDelegate { SessionContext = this },
                LocalizationDelegate = new GameLocalizationDelegate { SessionContext = this },
                SessionContext = this

                // ...
            });

            // ...

            Update();
        }

        public void Update()
        {
            // Z111
            MetaplaySDK.Update();

            // ...
        }

        private static ServerEndpoint GetServerEndpoint()
        {
            var selected = DeploymentConfig.Selected;
            if (selected.IsOfflineMode)
                return new ServerEndpoint();

            return new ServerEndpoint(selected.ServerHost, selected.ServerPort, selected.EnableTls, selected.CdnBaseUrl, selected.BackupGateways?.Select(x => x.ToGateway(selected.EnableTls)).ToList() ?? new List<ServerGateway>());
        }
    }
}

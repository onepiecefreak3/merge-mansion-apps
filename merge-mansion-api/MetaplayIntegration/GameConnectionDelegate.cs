using System;
using Metaplay.GameLogic.Config;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Client;
using Metaplay.Metaplay.Unity.DefaultIntegration;
using Metaplay.ThirdParty;

namespace Metaplay.MetaplayIntegration
{
    public class GameConnectionDelegate : DefaultMetaplayConnectionDelegate
    {
        public override void OnSessionStarted(ClientSessionStartResources startResources)
        {
            ClientGlobal.LogicVersion = startResources.LogicVersion;

            var gameConfig = startResources.GameConfigs[ClientSlotCore.Player];
            if (gameConfig == null)
            {
                ClientGlobal.SharedGameConfig = null;
                return;
            }

            ClientGlobal.SharedGameConfig = (SharedGameConfig)gameConfig;
        }

        public override SocialAuthenticationClaimBase GetSocialAuthLoginCredentials()
        {
            return SupercellIntegration.Instance.GetCurrentAccountCredentials();
        }
    }
}

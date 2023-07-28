using GameLogic.Config;
using Metaplay.Core;
using Metaplay.Core.Client;
using Metaplay.Unity.DefaultIntegration;
using ThirdParty;

namespace MetaplayIntegration
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

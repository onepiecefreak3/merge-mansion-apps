using GameLogic.IAP;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(7)]
    public class RewardIAP : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IAPTags IAPTag { get; set; }

        public RewardIAP()
        {
        }

        public RewardIAP(IAPTags tag)
        {
        }
    }
}
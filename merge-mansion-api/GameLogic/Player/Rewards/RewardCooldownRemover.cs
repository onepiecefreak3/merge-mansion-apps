using Metaplay.Core.Model;
using Metaplay.Core;
using Metaplay.Core.Forms;

namespace GameLogic.Player.Rewards
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(26)]
    public class RewardCooldownRemover : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        public RewardCooldownRemover()
        {
        }

        public RewardCooldownRemover(MetaDuration duration)
        {
        }
    }
}
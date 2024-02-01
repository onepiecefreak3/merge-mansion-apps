using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Rewards
{
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
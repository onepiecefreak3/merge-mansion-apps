using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(23)]
    public class RewardActivateInfiniteEnergy : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration Duration { get; set; }

        public RewardActivateInfiniteEnergy()
        {
        }

        public RewardActivateInfiniteEnergy(MetaDuration duration)
        {
        }
    }
}
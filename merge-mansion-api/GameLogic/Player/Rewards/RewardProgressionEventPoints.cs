using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(36)]
    public class RewardProgressionEventPoints : PlayerReward
    {
        private static string DailyChallengeReward;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardProgressionEventPoints()
        {
        }

        public RewardProgressionEventPoints(int amount, CurrencySource source)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(35)]
    public class RewardDailyScoopPoints : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardDailyScoopPoints()
        {
        }

        public RewardDailyScoopPoints(int amount, CurrencySource source)
        {
        }
    }
}
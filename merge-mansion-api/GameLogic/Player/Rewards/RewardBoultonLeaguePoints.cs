using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(38)]
    public class RewardBoultonLeaguePoints : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        private RewardBoultonLeaguePoints()
        {
        }

        public RewardBoultonLeaguePoints(int amount, CurrencySource currencySource)
        {
        }
    }
}
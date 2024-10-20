using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(14)]
    public class RewardEventPoints : PlayerReward
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardEventPoints()
        {
        }

        public RewardEventPoints(int amount, CurrencySource currencySource)
        {
        }
    }
}
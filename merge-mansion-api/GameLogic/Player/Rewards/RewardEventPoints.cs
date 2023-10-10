using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(14)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class RewardEventPoints : PlayerReward
    {
        [MetaMember(2, 0)]
        public int Amount { get; set; }

        public RewardEventPoints()
        {
        }

        public RewardEventPoints(int amount, CurrencySource currencySource)
        {
        }
    }
}
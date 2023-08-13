using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(12)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class RewardEventCurrency : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }

        [MetaMember(2, 0)]
        public int Amount { get; set; }

        public RewardEventCurrency()
        {
        }

        public RewardEventCurrency(EventCurrencyId eventCurrencyId, int amount, CurrencySource currencySource)
        {
        }
    }
}
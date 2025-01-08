using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaBlockedMembers(new int[] { 3 })]
    [MetaSerializableDerived(12)]
    public class RewardEventCurrency : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventCurrencyId EventCurrencyId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardEventCurrency()
        {
        }

        public RewardEventCurrency(EventCurrencyId eventCurrencyId, int amount, CurrencySource currencySource)
        {
        }
    }
}
using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Costs
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class EventCurrencyCost : CurrencyCost
    {
        [MetaMember(2, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
        public override Currencies Currency => Currencies.EventCurrency;

        private EventCurrencyCost()
        {
        }

        public EventCurrencyCost(EventCurrencyId eventCurrencyId, long currencyAmount)
        {
        }
    }
}
using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1034)]
    public class PlayerEventCurrencyAmount : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private EventCurrencyId CurrencyId { get; set; }
        public override string DisplayName { get; }

        public PlayerEventCurrencyAmount()
        {
        }

        public PlayerEventCurrencyAmount(EventCurrencyId currencyId)
        {
        }
    }
}
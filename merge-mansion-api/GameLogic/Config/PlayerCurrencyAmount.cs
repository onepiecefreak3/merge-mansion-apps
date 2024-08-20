using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1050)]
    public class PlayerCurrencyAmount : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies CurrencyId { get; set; }
        public override string DisplayName { get; }

        public PlayerCurrencyAmount()
        {
        }

        public PlayerCurrencyAmount(Currencies currencyId)
        {
        }
    }
}
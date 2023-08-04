using Metaplay.Core.Model;
using System;

namespace GameLogic.Config.Costs
{
    [MetaSerializable]
    public abstract class CurrencyCost : ICost
    {
        [MetaMember(1, 0)]
        public long CurrencyAmount { get; set; }
        public abstract Currencies Currency { get; }

        protected CurrencyCost()
        {
        }

        protected CurrencyCost(long currencyAmount)
        {
        }
    }
}
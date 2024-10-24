using Metaplay.Core.Model;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public struct CurrencyPricePair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }
        public static CurrencyPricePair Zero { get; }
    }
}
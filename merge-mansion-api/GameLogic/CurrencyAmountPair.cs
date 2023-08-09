using Metaplay.Core.Model;
using System;

namespace GameLogic
{
    [MetaSerializable]
    public class CurrencyAmountPair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int amount { get; set; }

        public CurrencyAmountPair()
        {
        }
    }
}
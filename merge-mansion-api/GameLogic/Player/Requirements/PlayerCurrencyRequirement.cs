using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(22)]
    public class PlayerCurrencyRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private long? Min { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private long? Max { get; set; }

        public PlayerCurrencyRequirement()
        {
        }

        public PlayerCurrencyRequirement(Currencies currency, long? min, long? max)
        {
        }
    }
}
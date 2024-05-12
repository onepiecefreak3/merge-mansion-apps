using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(38)]
    public class PlayerCurrencyComparedToSessionStartRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private long? Amount { get; set; }

        public PlayerCurrencyComparedToSessionStartRequirement()
        {
        }

        public PlayerCurrencyComparedToSessionStartRequirement(Currencies currency, long? amount)
        {
        }
    }
}
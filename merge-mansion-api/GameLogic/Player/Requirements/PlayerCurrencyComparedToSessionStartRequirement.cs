using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(38)]
    public class PlayerCurrencyComparedToSessionStartRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        public PlayerCurrencyComparedToSessionStartRequirement()
        {
        }

        public PlayerCurrencyComparedToSessionStartRequirement(Currencies currency, long? amount)
        {
        }

        public PlayerCurrencyComparedToSessionStartRequirement(Currencies currency)
        {
        }
    }
}
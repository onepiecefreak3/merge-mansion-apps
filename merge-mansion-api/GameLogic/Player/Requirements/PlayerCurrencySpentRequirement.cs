using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(37)]
    public class PlayerCurrencySpentRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private long? Amount { get; set; }

        public PlayerCurrencySpentRequirement()
        {
        }

        public PlayerCurrencySpentRequirement(Currencies currency, long? amount)
        {
        }
    }
}
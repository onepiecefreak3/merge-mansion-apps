using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(36)]
    public class PlayerCurrencyGainedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private long? Amount { get; set; }

        public PlayerCurrencyGainedRequirement()
        {
        }

        public PlayerCurrencyGainedRequirement(Currencies currency, long? amount)
        {
        }
    }
}
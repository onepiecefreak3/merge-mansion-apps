using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1041)]
    public class AverageNumberOfTransactionsInNDays : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }

        public AverageNumberOfTransactionsInNDays()
        {
        }

        public AverageNumberOfTransactionsInNDays(int days)
        {
        }
    }
}
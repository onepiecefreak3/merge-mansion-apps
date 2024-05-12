using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1042)]
    public class AverageTransactionValueInNDays : TypedPlayerPropertyId<F64>
    {
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }

        public AverageTransactionValueInNDays()
        {
        }

        public AverageTransactionValueInNDays(int days)
        {
        }
    }
}
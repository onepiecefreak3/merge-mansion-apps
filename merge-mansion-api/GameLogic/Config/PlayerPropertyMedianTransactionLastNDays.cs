using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1051)]
    public class PlayerPropertyMedianTransactionLastNDays : TypedPlayerPropertyId<F64>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }
        public override string DisplayName { get; }

        public PlayerPropertyMedianTransactionLastNDays()
        {
        }

        public PlayerPropertyMedianTransactionLastNDays(int days)
        {
        }
    }
}
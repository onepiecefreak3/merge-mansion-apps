using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1016)]
    public class PlayerPropertyHighestTransactionPriceLast30Days : TypedPlayerPropertyId<F64>
    {
        public override string DisplayName => "Highest transactions price from last 30 days";

        public PlayerPropertyHighestTransactionPriceLast30Days()
        {
        }
    }
}
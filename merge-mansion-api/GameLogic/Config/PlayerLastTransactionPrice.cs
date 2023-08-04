using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1027)]
    public class PlayerLastTransactionPrice : TypedPlayerPropertyId<F64>
    {
        public override string DisplayName { get; }

        public PlayerLastTransactionPrice()
        {
        }
    }
}
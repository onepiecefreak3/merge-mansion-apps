using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(2)]
    public class PlayerPropertyIdCoins : TypedPlayerPropertyId<long>
    {
        public override string DisplayName => "Coins";

        public PlayerPropertyIdCoins()
        {
        }
    }
}
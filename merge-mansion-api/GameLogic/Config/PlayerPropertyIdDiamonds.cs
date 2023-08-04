using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class PlayerPropertyIdDiamonds : TypedPlayerPropertyId<long>
    {
        public override string DisplayName { get; }

        public PlayerPropertyIdDiamonds()
        {
        }
    }
}
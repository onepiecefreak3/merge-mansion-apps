using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1021)]
    public class PlayerIsDeveloper : TypedPlayerPropertyId<bool>
    {
        public override string DisplayName { get; }

        public PlayerIsDeveloper()
        {
        }
    }
}
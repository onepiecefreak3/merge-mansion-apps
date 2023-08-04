using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1002)]
    public class PlayerPropertyAccountAge : TypedPlayerPropertyId<MetaDuration>
    {
        public override string DisplayName { get; }

        public PlayerPropertyAccountAge()
        {
        }
    }
}
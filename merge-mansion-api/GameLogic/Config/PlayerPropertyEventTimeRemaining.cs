using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1011)]
    public class PlayerPropertyEventTimeRemaining : TypedPlayerPropertyId<MetaDuration>
    {
        public override string DisplayName => "Event time remaining";

        public PlayerPropertyEventTimeRemaining()
        {
        }
    }
}
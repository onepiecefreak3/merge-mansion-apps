using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1010)]
    public class PlayerPropertyCurrentEvent : TypedPlayerPropertyId<string>
    {
        public override string DisplayName => "Current event";

        public PlayerPropertyCurrentEvent()
        {
        }
    }
}
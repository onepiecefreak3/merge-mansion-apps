using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1003)]
    public class PlayerPropertyTimeSinceLastLogin : TypedPlayerPropertyId<MetaDuration>
    {
        public override string DisplayName => "Time since last login";

        public PlayerPropertyTimeSinceLastLogin()
        {
        }
    }
}
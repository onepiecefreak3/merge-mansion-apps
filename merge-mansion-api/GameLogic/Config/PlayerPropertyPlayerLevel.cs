using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1004)]
    public class PlayerPropertyPlayerLevel : TypedPlayerPropertyId<int>
    {
        public override string DisplayName => "Player level";

        public PlayerPropertyPlayerLevel()
        {
        }
    }
}
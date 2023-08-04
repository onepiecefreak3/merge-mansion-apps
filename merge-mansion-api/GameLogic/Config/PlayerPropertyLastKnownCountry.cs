using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1000)]
    public class PlayerPropertyLastKnownCountry : TypedPlayerPropertyId<string>
    {
        public override string DisplayName { get; }

        public PlayerPropertyLastKnownCountry()
        {
        }
    }
}
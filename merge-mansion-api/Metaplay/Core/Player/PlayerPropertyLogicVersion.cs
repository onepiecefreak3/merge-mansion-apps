using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(101)]
    public class PlayerPropertyLogicVersion : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public PlayerPropertyLogicVersion()
        {
        }
    }
}
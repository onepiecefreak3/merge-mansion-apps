using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1047)]
    public class SystemMemoryMegabytes : TypedPlayerPropertyId<int>
    {
        public override string DisplayName { get; }

        public SystemMemoryMegabytes()
        {
        }
    }
}
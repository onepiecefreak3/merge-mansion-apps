using System;

namespace Metaplay.Core.Model
{
    [Flags]
    public enum MetaSerializableFlags
    {
        None = 0,
        ImplicitMembers = 2
    }
}
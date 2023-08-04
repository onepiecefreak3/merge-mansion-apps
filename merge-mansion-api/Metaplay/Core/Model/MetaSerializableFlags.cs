using System;

namespace Metaplay.Core.Model
{
    [Flags]
    public enum MetaSerializableFlags
    {
        None = 0,
        Public = 1,
        ImplicitMembers = 2
    }
}
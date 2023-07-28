using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
    public sealed class MetaSerializableAttribute : Attribute
    {
        public readonly MetaSerializableFlags Flags; // 0x10

        public MetaSerializableAttribute() { }

        public MetaSerializableAttribute(MetaSerializableFlags flags)
        {
            Flags = flags;
        }
    }
}

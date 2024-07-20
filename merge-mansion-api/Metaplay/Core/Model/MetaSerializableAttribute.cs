using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)1052)]
    public class MetaSerializableAttribute : Attribute
    {
        public readonly MetaSerializableFlags Flags; // 0x10
        public MetaSerializableAttribute()
        {
        }

        public MetaSerializableAttribute(MetaSerializableFlags flags)
        {
            Flags = flags;
        }
    }
}
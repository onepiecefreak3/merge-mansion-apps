using System;
using System.Collections.Generic;

namespace Metaplay.Core.Serialization
{
    public struct MetaSerializerTypeInfo // TypeDefIndex: 6486
    {
        // Fields
        public Dictionary<Type, MetaSerializableType> Specs; // 0x0
        public uint FullTypeHash; // 0x8
        public MetaSerializerTypeInfo()
        {
        }
    }
}
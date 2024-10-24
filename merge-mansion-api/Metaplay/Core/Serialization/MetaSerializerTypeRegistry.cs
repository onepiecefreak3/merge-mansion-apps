using System.Collections.Generic;

namespace Metaplay.Core.Serialization
{
    public class MetaSerializerTypeRegistry
    {
        private static MetaSerializerTypeInfo _typeInfo; // 0x0
        public static uint FullProtocolHash => _typeInfo.FullTypeHash; // 0x10
        public static MetaSerializerTypeRegistry Instance { get; }
        public IEnumerable<MetaSerializableType> AllTypes { get; }
        public MetaSerializerTypeInfo TypeInfo { get; }

        public MetaSerializerTypeRegistry(MetaSerializerTypeInfo typeInfo)
        {
        }
    }
}
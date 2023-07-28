namespace Metaplay.Core.Serialization
{
    public class MetaSerializerTypeRegistry
    {
        private static MetaSerializerTypeInfo _typeInfo; // 0x0

        public static uint FullProtocolHash => _typeInfo.FullTypeHash; // 0x10
    }
}

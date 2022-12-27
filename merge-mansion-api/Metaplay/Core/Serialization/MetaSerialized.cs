using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Serialization
{
    public struct MetaSerialized<T>
    {
        [MetaMember(1, 0)]
        public byte[] Bytes { get; set; } // 0x0
        [MetaMember(2, 0)]
        public MetaSerializationFlags Flags { get; set; } // 0x8
    }
}

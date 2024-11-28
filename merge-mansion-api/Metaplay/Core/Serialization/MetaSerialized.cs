using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Serialization
{
    [MetaSerializable]
    public struct MetaSerialized<T>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public byte[] Bytes { get; set; } // 0x0

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaSerializationFlags Flags { get; set; } // 0x8

        public static MetaSerialized<T> Empty;
        public bool IsValid { get; }
        public bool IsEmpty { get; }
    }
}
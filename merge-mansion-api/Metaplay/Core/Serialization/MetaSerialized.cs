using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Serialization
{
    public struct MetaSerialized<T>
    {
        [MetaMember(1, 0)]
        public byte[] Bytes { get; set; } // 0x0

        [MetaMember(2, 0)]
        public MetaSerializationFlags Flags { get; set; } // 0x8

        public static MetaSerialized<T> Empty;
        public bool IsValid { get; }
        public bool IsEmpty { get; }
    }
}
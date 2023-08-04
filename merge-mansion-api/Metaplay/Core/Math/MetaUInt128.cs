using System;

namespace Metaplay.Core.Math
{
    public struct MetaUInt128
    {
        public ulong High;
        public ulong Low;
        public static MetaUInt128 Zero { get; }
        public static MetaUInt128 One { get; }
    }
}
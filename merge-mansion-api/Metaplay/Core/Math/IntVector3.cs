using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Math
{
    [MetaSerializable]
    public struct IntVector3
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int X;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Y;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Z;
        public static IntVector3 Zero { get; }
        public static IntVector3 One { get; }
        public static IntVector3 Down { get; }
        public static IntVector3 Up { get; }
        public static IntVector3 Left { get; }
        public static IntVector3 Right { get; }
        public static IntVector3 Forward { get; }
        public static IntVector3 Back { get; }
    }
}
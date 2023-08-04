using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Math
{
    [MetaSerializable]
    public struct IntVector2
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int X;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Y;
        public static IntVector2 Zero { get; }
        public static IntVector2 One { get; }
        public static IntVector2 Down { get; }
        public static IntVector2 Up { get; }
        public static IntVector2 Left { get; }
        public static IntVector2 Right { get; }
    }
}
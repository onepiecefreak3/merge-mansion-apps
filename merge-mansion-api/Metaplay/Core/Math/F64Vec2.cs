using System;

namespace Metaplay.Core.Math
{
    public struct F64Vec2
    {
        public long RawX;
        public long RawY;
        public static F64Vec2 Zero { get; }
        public static F64Vec2 One { get; }
        public static F64Vec2 Down { get; }
        public static F64Vec2 Up { get; }
        public static F64Vec2 Left { get; }
        public static F64Vec2 Right { get; }
        public static F64Vec2 AxisX { get; }
        public static F64Vec2 AxisY { get; }
        public F64 X { get; set; }
        public F64 Y { get; set; }
    }
}
using FixPointCS;
using System;

namespace Metaplay.Core.Math
{
    public struct F64
    {
        public static F64 Neg1 => new(unchecked((long)0xFFFFFFFF00000000));
        public static F64 Zero => new();
        public static F64 Half => new(0x80000000);
        public static F64 One => new(0x100000000);
        public static F64 Two => new(0x200000000);
        public static F64 Pi => new(0x3243F6A89);
        public static F64 Pi2 => new(0x6487ED511);
        public static F64 PiHalf => new(0x1921FB544);
        public static F64 E => new(0x2B7E15163);
        public static F64 MinValue => new(unchecked((long)0x8000000000000000));
        public static F64 MaxValue => new(0x7FFFFFFFFFFFFFFF);

        public long Raw; // 0x0
        public F64(long raw)
        {
            Raw = raw;
        }

        public static F64 FromInt(int v)
        {
            return new F64((long)v << 32);
        }

        public static F64 FromDouble(double value)
        {
            return new F64((long)(value * 4294967296)); // Shift left by 32
        }

        public F32 F32 => new((int)((Raw >> 16) & 0xFFFFFFFF));
        public float Float => Raw * 2.328306e-10f;
        public double Double => Raw * 2.328306436538696e-10;

        public static F64 operator +(F64 a, F64 b) => new F64(a.Raw + b.Raw);
        public static F64 operator +(int a, F64 b) => new F64(((long)a << 32) + b.Raw);
        public static F64 operator +(F64 a, int b) => new F64(((long)b << 32) + a.Raw);
        public static F64 operator -(F64 a, F64 b) => new F64(a.Raw - b.Raw);
        public static F64 operator -(int a, F64 b) => new F64(((long)a << 32) - b.Raw);
        public static F64 operator -(F64 a, int b) => new F64(a.Raw - ((long)b << 32));
        public static F64 operator *(F64 v1, F64 v2) => new F64((v1.Raw >> 32) * v2.Raw + (v2.Raw >> 32) * (v1.Raw & 0xFFFFFFFF) + (v2.Raw & 0xFFFFFFFF) * ((v1.Raw & 0xFFFFFFFF) >> 32));
        public static F64 operator *(F64 v1, int v2) => new F64(v1.Raw * v2);
        public static F64 operator *(int v1, F64 v2) => new F64(v1 * v2.Raw);
        public static F64 operator /(F64 v1, F64 v2) => new F64(Fixed64.DivPrecise(v1.Raw, v2.Raw));
        public static F64 operator /(F64 v1, int v2) => new F64(v1.Raw / v2);
        public static F64 operator /(int v1, F64 v2) => new F64(Fixed64.DivPrecise((long)v1 << 32, v2.Raw));
        public static bool operator>(F64 v1, F64 v2) => v1.Raw > v2.Raw;
        public static bool operator>(int v1, F64 v2) => (long)v1 << 32 > v2.Raw;
        public static bool operator>(F64 v1, int v2) => v1.Raw > (long)v2 << 32;
        public static bool operator <(F64 v1, F64 v2) => v1.Raw < v2.Raw;
        public static bool operator <(int v1, F64 v2) => (long)v1 << 32 < v2.Raw;
        public static bool operator <(F64 v1, int v2) => v1.Raw < (long)v2 << 32;
        public override string ToString()
        {
            return Double.ToString();
        }

        private static long[] _longPow10Table;
    }
}
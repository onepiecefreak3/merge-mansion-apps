using FixPointCS;

namespace Metaplay.Metaplay.Core.Math
{
    public struct F64
    {
        public static F64 Zero = new F64(0);

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

        public double Double => Raw * 2.328306436538696e-10;

        public static F64 operator +(F64 a, F64 b) => new F64(a.Raw + b.Raw);
        public static F64 operator +(int a, F64 b) => new F64(((long)a << 32) + b.Raw);
        public static F64 operator +(F64 a, int b) => new F64(((long)b << 32) + a.Raw);

        public static F64 operator *(F64 v1, F64 v2) => new F64((v1.Raw >> 32) * v2.Raw + (v2.Raw >> 32) * (v1.Raw & 0xFFFFFFFF) + (v2.Raw & 0xFFFFFFFF) * ((v1.Raw & 0xFFFFFFFF) >> 32));
        public static F64 operator *(F64 v1, int v2) => new F64(v1.Raw * v2);
        public static F64 operator *(int v1, F64 v2) => new F64(v1 * v2.Raw);

        public static F64 operator /(F64 v1, F64 v2) => new F64(Fixed64.DivPrecise(v1.Raw, v2.Raw));
        public static F64 operator /(F64 v1, int v2) => new F64(v1.Raw / v2);
        public static F64 operator /(int v1, F64 v2) => new F64(Fixed64.DivPrecise((long)v1 << 32, v2.Raw));

        public override string ToString()
        {
            return Double.ToString();
        }
    }
}

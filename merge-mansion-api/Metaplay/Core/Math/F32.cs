using FixPointCS;

namespace Metaplay.Core.Math
{
    public struct F32
    {
        public int Raw; // 0x0
        public float Float => Fixed32.ToFloat(Raw);
        public double Double => Fixed32.ToDouble(Raw);

        public F32(int raw)
        {
            Raw = raw;
        }

        public static F32 FromInt(int v)
        {
            return new F32(v << 16);
        }

        public static F32 FromFloat(float v)
        {
            return new F32((int)(v * 65536)); // Shift left by 16
        }

        public static F32 Ratio(int a, int b)
        {
            if (b == 0)
                return FromInt(0);
            return FromInt(a / b);
        }

        public static F32 Rcp(F32 a)
        {
            return new F32(Fixed32.Rcp(a.Raw));
        }

        public static F32 operator +(F32 v1, F32 v2) => new F32(v1.Raw + v2.Raw);
        public static F32 operator +(int v1, F32 v2) => new F32(v1 << 16 + v2.Raw);
        public static F32 operator +(F32 v1, int v2) => new F32(v1.Raw + v2 << 16);
        public static bool operator <(F32 v1, F32 v2) => v1.Raw < v2.Raw;
        public static bool operator <(int v1, F32 v2) => v1 << 16 < v2.Raw;
        public static bool operator <(F32 v1, int v2) => v1.Raw < v2 << 16;
        public static bool operator>(F32 v1, F32 v2) => v1.Raw > v2.Raw;
        public static bool operator>(int v1, F32 v2) => v1 << 16 > v2.Raw;
        public static bool operator>(F32 v1, int v2) => v1.Raw > v2 << 16;
        public static bool operator !=(F32 v1, F32 v2) => v1.Raw != v2.Raw;
        public static bool operator !=(int v1, F32 v2) => v1 << 16 != v2.Raw;
        public static bool operator !=(F32 v1, int v2) => v1.Raw != v2 << 16;
        public static bool operator ==(F32 v1, F32 v2) => v1.Raw == v2.Raw;
        public static bool operator ==(int v1, F32 v2) => v1 << 16 == v2.Raw;
        public static bool operator ==(F32 v1, int v2) => v1.Raw == v2 << 16;
        public override string ToString()
        {
            return Fixed32.ToString(Raw);
        }

        public static F32 Neg1 { get; }
        public static F32 Zero { get; }
        public static F32 Half { get; }
        public static F32 One { get; }
        public static F32 Two { get; }
        public static F32 Pi { get; }
        public static F32 Pi2 { get; }
        public static F32 PiHalf { get; }
        public static F32 E { get; }
        public static F32 MinValue { get; }
        public static F32 MaxValue { get; }
    }
}
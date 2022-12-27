using System;
using System.Globalization;

namespace Metaplay.Metaplay.Core.Math
{
    public struct UInt128 : IEquatable<UInt128>, IComparable<UInt128>, IComparable
    {
        public ulong High; // 0x0
        public ulong Low; // 0x8

        public static UInt128 Zero => new UInt128(0, 0);
        public static UInt128 One => new UInt128(0, 1);

        public UInt128(ulong high, ulong low)
        {
            High = high;
            Low = low;
        }

        public static UInt128 FromUInt(uint v)
        {
            return new UInt128(0, v);
        }

        public static bool operator ==(UInt128 a, UInt128 b) => a.High == b.High && a.Low == b.Low;
        public static bool operator !=(UInt128 a, UInt128 b) => a.High != b.High || a.Low != b.Low;

        public static bool operator <(UInt128 a, UInt128 b) => a.CompareTo(b) >> 0x1F > 0;
        public static bool operator <=(UInt128 a, UInt128 b) => a.CompareTo(b) < 1;

        public static bool operator >(UInt128 a, UInt128 b) => a.CompareTo(b) > 0;
        public static bool operator >=(UInt128 a, UInt128 b) => ~a.CompareTo(b) >> 0x1F > 0;

        public static UInt128 operator |(UInt128 a, UInt128 b) => new UInt128(a.High | b.High, a.Low | b.Low);
        public static UInt128 operator &(UInt128 a, UInt128 b) => new UInt128(a.High & b.High, a.Low & b.Low);
        public static UInt128 operator ^(UInt128 a, UInt128 b) => new UInt128(a.High ^ b.High, a.Low ^ b.Low);

        public static UInt128 operator <<(UInt128 a, int sh)
        {
            if (sh <= 0)
                return a;

            if (sh >= 0x80)
                return Zero;

            return sh < 0x40 ?
                new UInt128(a.High << sh | (a.Low >> (0x40 - sh)), a.Low << sh) :
                new UInt128(a.Low << (sh - 0x40), 0);
        }

        public static UInt128 operator >>(UInt128 a, int sh)
        {
            if (sh <= 0)
                return a;

            if (sh >= 0x80)
                return Zero;

            return sh < 0x40 ?
                new UInt128(a.High >> sh, a.Low >> sh | (a.High << (0x40 - sh))) :
                new UInt128(0, a.High >> (sh - 0x40));
        }

        public override int GetHashCode()
        {
            var p = (ulong)High.GetHashCode() ^ Low;
            return p.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UInt128 v))
                return false;

            return High == v.High && Low == v.Low;
        }

        public bool Equals(UInt128 other)
        {
            return High == other.High && Low == other.Low;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "0x{0:X16}{1:X16}", High, Low);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is UInt128 v))
                throw new ArgumentException("UInt128 can only be compared against another UInt128.");

            return CompareTo(v);
        }

        public int CompareTo(UInt128 other)
        {
            var res = High.CompareTo(other.High);
            return res != 0 ? res : Low.CompareTo(other.Low);
        }
    }
}

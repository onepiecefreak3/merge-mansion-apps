using System;
using System.Text.RegularExpressions;
using Metaplay.Core.Model;

namespace Metaplay.Core
{
    public struct MetaDuration : IEquatable<MetaDuration>, IComparable<MetaDuration>, IComparable
    {
        // 0x0
        public static readonly MetaDuration Zero = default;
        // 0x8
        private static Regex s_pattern = new Regex(@"^(\-)?(\d+)\.(\d{2}):(\d{2}):(\d{2})\.(\d{7})$", RegexOptions.Compiled);

        // 0x0
        [MetaMember(1)]
        public long Milliseconds { get; set; }

        public static MetaDuration FromDays(int days)
        {
            return new MetaDuration(days * 86400000);
        }

        public static MetaDuration FromHours(int hours)
        {
            return new MetaDuration(hours * 3600000);
        }

        public static MetaDuration FromMinutes(int minutes)
        {
            return new MetaDuration(minutes * 60000);
        }

        public static MetaDuration FromSeconds(long seconds)
        {
            return new MetaDuration(seconds * 1000);
        }

        public static MetaDuration FromMilliseconds(long milliseconds)
        {
            return new MetaDuration(milliseconds);
        }

        public MetaDuration(long milliseconds)
        {
            Milliseconds = milliseconds;
        }

        public int ToLocalTicks(int ticksPerSecond)
        {
            return (int)(Milliseconds / 1000 * ticksPerSecond);
        }

        public double ToSecondsDouble()
        {
            return Milliseconds / 1000d;
        }

        public static MetaDuration FromTimeSpan(TimeSpan span)
        {
            return new MetaDuration(span.Ticks / 10000);
        }

        public TimeSpan ToTimeSpan()
        {
            return TimeSpan.FromTicks(Milliseconds * 10000);
        }

        public static bool operator ==(MetaDuration a, MetaDuration b) => a.Milliseconds == b.Milliseconds;
        public static bool operator !=(MetaDuration a, MetaDuration b) => a.Milliseconds != b.Milliseconds;

        public static bool operator <(MetaDuration a, MetaDuration b) => a.Milliseconds < b.Milliseconds;
        public static bool operator <=(MetaDuration a, MetaDuration b) => a.Milliseconds <= b.Milliseconds;

        public static bool operator >(MetaDuration a, MetaDuration b) => a.Milliseconds > b.Milliseconds;
        public static bool operator >=(MetaDuration a, MetaDuration b) => a.Milliseconds >= b.Milliseconds;

        public static MetaDuration operator +(MetaDuration a, MetaDuration b) => new MetaDuration(b.Milliseconds + a.Milliseconds);
        public static MetaDuration operator -(MetaDuration a, MetaDuration b) => new MetaDuration(a.Milliseconds - b.Milliseconds);
        public static MetaDuration operator *(MetaDuration a, int b) => new MetaDuration(a.Milliseconds * b);
        public static MetaDuration operator *(int a, MetaDuration b) => new MetaDuration(a * b.Milliseconds);
        public static float operator /(MetaDuration a, MetaDuration b) => (float)a.Milliseconds / b.Milliseconds;

        public static MetaDuration operator -(MetaDuration a) => new MetaDuration(-a.Milliseconds);

        public static MetaDuration Max(MetaDuration a, MetaDuration b) => a.Milliseconds >= b.Milliseconds ? a : b;
        public static MetaDuration Min(MetaDuration a, MetaDuration b) => a.Milliseconds <= b.Milliseconds ? a : b;

        public bool Equals(MetaDuration other)=> Milliseconds == other.Milliseconds;

        public override int GetHashCode() => Milliseconds.GetHashCode();

        public override bool Equals(object obj)
        {
            if (!(obj is MetaDuration v))
                return false;

            return v.Milliseconds == Milliseconds;
        }

        public int CompareTo(MetaDuration other)
        {
            return Milliseconds.CompareTo(other.Milliseconds);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (!(obj is MetaDuration v))
                throw new ArgumentException();

            return Milliseconds.CompareTo(v.Milliseconds);
        }

        //public override string ToString() { }
    }
}

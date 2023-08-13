using System;
using System.Globalization;
using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public struct MetaTime
    {
        // 0x0
        public static MetaDuration DebugTimeOffset = MetaDuration.Zero;
        // 0x8
        public static readonly MetaTime Epoch = default;
        // 0x10
        public static readonly DateTime DateTimeEpoch = new(1970, 1, 1, 0, 0, 0, 1, 0);
        // 0x18
        private static readonly ConfigLexer.CustomTokenSpec s_dateConfigToken = new("([0-9]|-)+", "Date part of MetaTime");
        // 0x20
        private static readonly ConfigLexer.CustomTokenSpec s_timeOfDayConfigToken = new("([0-9]|:|\\.)+", "Time-of-day part of MetaTime");
        // 0x28
        private static readonly string s_dateFormat = "yyyy-M-d";
        // 0x30
        private static readonly string[] s_timeOfDayFormats =
        {
            "H:m",
            "H:m:s.FFF"
        };
        // 0x0
        [MetaMember(1)]
        public long MillisecondsSinceEpoch { get; set; }
        public static MetaTime Now => FromDateTime(DateTime.UtcNow);

        private MetaTime(long millisecondsSinceEpoch)
        {
            MillisecondsSinceEpoch = millisecondsSinceEpoch;
        }

        public static MetaTime FromMillisecondsSinceEpoch(long millisecondsSinceEpoch)
        {
            return new MetaTime(millisecondsSinceEpoch);
        }

        public static MetaTime FromDateTime(DateTime dt)
        {
            return new MetaTime((dt - DateTimeEpoch).Ticks / 10000);
        }

        public DateTime ToDateTime()
        {
            return DateTimeEpoch + TimeSpan.FromTicks(MillisecondsSinceEpoch * 10000);
        }

        public DateTime ToLocalDateTime()
        {
            return ToDateTime().ToLocalTime();
        }

        public static bool operator ==(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch == b.MillisecondsSinceEpoch;
        public static bool operator !=(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch != b.MillisecondsSinceEpoch;
        public static bool operator <(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch < b.MillisecondsSinceEpoch;
        public static bool operator <=(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch <= b.MillisecondsSinceEpoch;
        public static bool operator>(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch > b.MillisecondsSinceEpoch;
        public static bool operator >=(MetaTime a, MetaTime b) => a.MillisecondsSinceEpoch >= b.MillisecondsSinceEpoch;
        public static MetaTime operator +(MetaTime a, MetaDuration b) => new MetaTime(b.Milliseconds + a.MillisecondsSinceEpoch);
        public static MetaTime operator +(MetaDuration a, MetaTime b) => new MetaTime(a.Milliseconds + b.MillisecondsSinceEpoch);
        public static MetaTime operator -(MetaTime a, MetaDuration b) => new MetaTime(a.MillisecondsSinceEpoch - b.Milliseconds);
        public static MetaDuration operator -(MetaTime a, MetaTime b) => new MetaDuration(a.MillisecondsSinceEpoch - b.MillisecondsSinceEpoch);
        public static MetaTime Min(MetaTime a, MetaTime b) => new MetaTime(System.Math.Min(a.MillisecondsSinceEpoch, b.MillisecondsSinceEpoch));
        public static MetaTime Max(MetaTime a, MetaTime b) => new MetaTime(System.Math.Max(a.MillisecondsSinceEpoch, b.MillisecondsSinceEpoch));
        public bool Equals(MetaTime other)
        {
            return MillisecondsSinceEpoch == other.MillisecondsSinceEpoch;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MetaTime v))
                return false;
            return MillisecondsSinceEpoch == v.MillisecondsSinceEpoch;
        }

        public override int GetHashCode()
        {
            return MillisecondsSinceEpoch.GetHashCode();
        }

        public override string ToString()
        {
            var dt = ToDateTime();
            return string.Format(CultureInfo.InvariantCulture, "{0}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}.{6:D3} Z", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        public string ToISO8601()
        {
            var dt = ToDateTime();
            return dt.ToString("o", CultureInfo.InvariantCulture);
        }

        public static MetaTime ConfigParse(ConfigLexer lexer)
        {
            // TODO: Activate with ConfigLexer
            throw new NotImplementedException();
        //var lexer1 = new ConfigLexer(lexer);
        //var canRead = lexer1.TryParseToken(ConfigLexer.TokenType.IntegerLiteral);
        //if (canRead && !lexer1.IsAtEnd)
        //    return new MetaTime(lexer.ParseLongLiteral() * 1000);
        //var canReadDate = lexer.TryParseCustomToken(s_dateConfigToken);
        //if (canReadDate == null)
        //    throw new ParseError("Failed to parse MetaTime. Expected either date-time format (e.g. 2022-6-20 12:34:56) or non-negative integer seconds since Unix epoch (legacy syntax). Input: " + lexer.GetRemainingInputInfo());
        //var isParsed = DateTime.TryParseExact(canReadDate, s_dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsedDate);
        //if (!isParsed)
        //    throw new ParseError("MetaTime: Failed to parse a date from string \"" + canReadDate + "\".Expected format " + s_dateFormat + ", with a 4-digit year, and 1 or 2-digit month and day.");
        //var canReadTime = lexer.TryParseCustomToken(s_timeOfDayConfigToken);
        //if (canReadTime == null)
        //    throw new ParseError("MetaTime: Time-of-day missing after date \"" + canReadDate + "\". Expected a time-of-day such as 12:34:56 . Input: " + lexer.GetRemainingInputInfo());
        //var isParsed1 = DateTime.TryParseExact(canReadTime, s_timeOfDayFormats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsedTime);
        //if (!isParsed1)
        //    throw new ParseError("MetaTime: Failed to parse a time-of-day from string \"" + canReadTime + "\".Expected one of these formats: " + s_timeOfDayFormats[0] + " or " + s_timeOfDayFormats[1] + " . The fractional seconds part is optional and has up to 3 digits if present. The other parts should have 1 or 2 digits each.");
        //if (canReadTime.EndsWith('.'))
        //    throw new ParseError("MetaTime: In time-of-day \"" + canReadTime + "\", the period after the seconds should be omitted if no digits come after it.");
        //return FromDateTime(new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, parsedTime.Hour, parsedTime.Minute, parsedTime.Second, parsedTime.Millisecond));
        }

        public int CompareTo(MetaTime other)
        {
            return MillisecondsSinceEpoch.CompareTo(other.MillisecondsSinceEpoch);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;
            if (!(obj is MetaTime v))
                throw new ArgumentException();
            return MillisecondsSinceEpoch.CompareTo(v.MillisecondsSinceEpoch);
        }
    }
}
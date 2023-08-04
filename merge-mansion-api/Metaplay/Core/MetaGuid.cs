using System;
using System.Text.RegularExpressions;
using Metaplay.Core.Math;

namespace Metaplay.Core
{
    public struct MetaGuid
    {
        public static MetaGuid None;
        public static DateTime MinDateTime;
        public static DateTime MaxDateTime;
        private static long EpochTicks;
        private static Regex s_pattern;
        public MetaUInt128 Value { get; set; }
        public bool IsValid { get; }
    }
}
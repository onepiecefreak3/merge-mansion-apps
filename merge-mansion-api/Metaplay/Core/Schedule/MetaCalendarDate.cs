using System;

namespace Metaplay.Core.Schedule
{
    public struct MetaCalendarDate
    {
        private static ConfigLexer.CustomTokenSpec s_dateConfigToken;
        private static string s_dateFormat;
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
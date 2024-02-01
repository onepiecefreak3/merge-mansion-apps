using System;

namespace Metaplay.Core.Schedule
{
    public struct MetaCalendarTime
    {
        private static ConfigLexer.CustomTokenSpec s_timeConfigToken;
        private static string[] s_timeFormats;
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }
}
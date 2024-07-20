using Metaplay.Core.Model;
using System.Text.RegularExpressions;
using System;
using System.ComponentModel;

namespace Metaplay.Core.Schedule
{
    [MetaSerializable]
    [TypeConverter(typeof(MetaCalendarPeriodTypeConverter))]
    public struct MetaCalendarPeriod
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Years; // 0x0
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Months; // 0x4
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Days; // 0x8
        [MetaMember(4, (MetaMemberFlags)0)]
        public int Hours; // 0xC
        [MetaMember(5, (MetaMemberFlags)0)]
        public int Minutes; // 0x10
        [MetaMember(6, (MetaMemberFlags)0)]
        public int Seconds; // 0x14
        public bool IsNone { get; }

        private static Regex s_isoPattern;
    }
}
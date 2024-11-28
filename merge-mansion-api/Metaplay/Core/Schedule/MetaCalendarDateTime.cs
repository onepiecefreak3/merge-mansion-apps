using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Schedule
{
    [MetaSerializable]
    public struct MetaCalendarDateTime
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Year { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Month { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Day { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Hour { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int Minute { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int Second { get; set; }

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }

        public MetaCalendarDate Date { get; set; }
        public MetaCalendarTime Time { get; set; }
    }
}
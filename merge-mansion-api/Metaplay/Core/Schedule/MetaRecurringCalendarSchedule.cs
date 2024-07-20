using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Schedule
{
    [MetaSerializableDerived(1)]
    public class MetaRecurringCalendarSchedule : MetaScheduleBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaCalendarDateTime Start { get; set; }

        [MetaMember(2)]
        public MetaCalendarPeriod Duration { get; set; }

        [MetaMember(7)]
        public MetaCalendarPeriod EndingSoon { get; set; }

        [MetaMember(3)]
        public MetaCalendarPeriod Preview { get; set; }

        [MetaMember(4)]
        public MetaCalendarPeriod Review { get; set; }

        [MetaMember(5)]
        public MetaCalendarPeriod? Recurrence { get; set; }

        [MetaMember(6)]
        public int? NumRepeats { get; set; }

        private MetaRecurringCalendarSchedule()
        {
        }

        public MetaRecurringCalendarSchedule(MetaScheduleTimeMode timeMode, MetaCalendarDateTime start, MetaCalendarPeriod duration, MetaCalendarPeriod endingSoon, MetaCalendarPeriod preview, MetaCalendarPeriod review, MetaCalendarPeriod? recurrence, int? numRepeats)
        {
        }
    }
}
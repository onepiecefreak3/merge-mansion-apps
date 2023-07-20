using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Schedule
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class MetaRecurringCalendarSchedule : MetaScheduleBase
    {
        [MetaMember(1)]
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
    }
}

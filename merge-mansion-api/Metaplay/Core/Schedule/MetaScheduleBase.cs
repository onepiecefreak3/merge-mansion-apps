using Metaplay.Core.Model;
using System;
using Metaplay.Core.Config;

namespace Metaplay.Core.Schedule
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    [ParseAsDerivedType(typeof(MetaRecurringCalendarSchedule))]
    public abstract class MetaScheduleBase
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public MetaScheduleTimeMode TimeMode { get; set; }

        static DateTime DateTimeEpoch;
        public MetaScheduleBase()
        {
        }

        public MetaScheduleBase(MetaScheduleTimeMode timeMode)
        {
        }
    }
}
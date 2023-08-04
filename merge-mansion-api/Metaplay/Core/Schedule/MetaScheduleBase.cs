using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Schedule
{
    [MetaSerializable]
    public abstract class MetaScheduleBase
    {
        [MetaMember(100)]
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
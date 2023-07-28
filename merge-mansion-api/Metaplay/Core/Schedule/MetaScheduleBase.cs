using Metaplay.Core.Model;

namespace Metaplay.Core.Schedule
{
    [MetaSerializable]
    public abstract class MetaScheduleBase
    {
        [MetaMember(100)]
        public MetaScheduleTimeMode TimeMode { get; set; }
    }
}

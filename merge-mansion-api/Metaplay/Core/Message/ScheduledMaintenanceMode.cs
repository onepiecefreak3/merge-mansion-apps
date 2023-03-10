using System.Collections.Generic;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
    public class ScheduledMaintenanceMode // TypeDefIndex: 966
    {
        [MetaMember(1, 0)]
        public MetaTime StartAt { get; set; } // 0x10
        [MetaMember(2, 0)]
        public int EstimatedDurationInMinutes { get; set; } // 0x18
        [MetaMember(3, 0)]
        public bool EstimationIsValid { get; set; } // 0x1C
        [MetaMember(4, 0)]
        public List<ClientPlatform> PlatformExclusions { get; set; } // 0x20

        public bool IsInMaintenanceMode(MetaTime time)
        {
            return time >= StartAt;
        }

        public ScheduledMaintenanceMode()
        { }

        public ScheduledMaintenanceMode(MetaTime startAt, int estimatedDurationInMinutes, bool estimationIsValid,
            List<ClientPlatform> platformExclusions)
        {
            StartAt = startAt;
            EstimatedDurationInMinutes = estimatedDurationInMinutes;
            EstimationIsValid = estimationIsValid;
            PlatformExclusions = platformExclusions;
        }
    }
}

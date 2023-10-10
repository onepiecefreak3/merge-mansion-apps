using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class ScheduledMaintenanceModeForClient
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime StartAt { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int EstimatedDurationInMinutes { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool EstimationIsValid { get; set; }

        private ScheduledMaintenanceModeForClient()
        {
        }

        public ScheduledMaintenanceModeForClient(MetaTime startAt, int estimatedDurationInMinutes, bool estimationIsValid)
        {
        }
    }
}
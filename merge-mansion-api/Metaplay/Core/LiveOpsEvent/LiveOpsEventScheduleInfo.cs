using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class LiveOpsEventScheduleInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<LiveOpsEventPhase, MetaTime> PhaseStartTimes { get; set; }

        private LiveOpsEventScheduleInfo()
        {
        }

        public LiveOpsEventScheduleInfo(Dictionary<LiveOpsEventPhase, MetaTime> phaseStartTimes)
        {
        }
    }
}
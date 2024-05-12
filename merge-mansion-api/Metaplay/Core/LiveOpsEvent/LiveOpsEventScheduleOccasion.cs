using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class LiveOpsEventScheduleOccasion
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<LiveOpsEventPhase, MetaTime> PhaseSequence { get; set; }

        private LiveOpsEventScheduleOccasion()
        {
        }

        public LiveOpsEventScheduleOccasion(Dictionary<LiveOpsEventPhase, MetaTime> phaseSequence)
        {
        }
    }
}
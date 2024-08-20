using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public class LiveOpsEventPhase : DynamicEnum<LiveOpsEventPhase>
    {
        public static LiveOpsEventPhase NotStartedYet;
        public static LiveOpsEventPhase Preview;
        public static LiveOpsEventPhase NormalActive;
        public static LiveOpsEventPhase EndingSoon;
        public static LiveOpsEventPhase Review;
        private static LiveOpsEventPhase[] s_fullPhaseSequence;
        public LiveOpsEventPhase(int id, string name) : base(id, name, true)
        {
        }

        public static LiveOpsEventPhase Concluded;
        private int _indexInPhaseSequence;
        public LiveOpsEventPhase(int id, string name, int indexInPhaseSequence) : base(id, name, true)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    public class MysteryMachineTotalScoreTask : IMysteryMachineTask
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private ulong BaseTarget { get; set; }

        private MysteryMachineTotalScoreTask()
        {
        }

        public MysteryMachineTotalScoreTask(ulong baseTarget)
        {
        }
    }
}
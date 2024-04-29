using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(1)]
    public class MysteryMachineScoreTask : IMysteryMachineTask
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int BaseTarget { get; set; }

        private MysteryMachineScoreTask()
        {
        }

        public MysteryMachineScoreTask(int baseTarget)
        {
        }
    }
}
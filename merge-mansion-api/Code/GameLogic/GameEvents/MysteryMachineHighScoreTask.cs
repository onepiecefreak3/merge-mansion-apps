using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class MysteryMachineHighScoreTask : IMysteryMachineTask
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int BaseTarget { get; set; }

        private MysteryMachineHighScoreTask()
        {
        }

        public MysteryMachineHighScoreTask(int baseTarget)
        {
        }
    }
}
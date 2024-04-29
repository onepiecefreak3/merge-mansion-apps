using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(5)]
    public class MysteryMachineScoreBeforeHeatLevelTask : IMysteryMachineTask
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int HeatLevel { get; set; }

        private MysteryMachineScoreBeforeHeatLevelTask()
        {
        }

        public MysteryMachineScoreBeforeHeatLevelTask(int score, int heatLevel)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class MysteryMachineHeatLevelTask : IMysteryMachineTask
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int HeatLevel { get; set; }

        private MysteryMachineHeatLevelTask()
        {
        }

        public MysteryMachineHeatLevelTask(int heatLevel)
        {
        }
    }
}
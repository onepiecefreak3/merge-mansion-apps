using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineTaskSource : IConfigItemSource<MysteryMachineTaskInfo, MysteryMachineTaskId>, IGameConfigSourceItem<MysteryMachineTaskId, MysteryMachineTaskInfo>, IHasGameConfigKey<MysteryMachineTaskId>
    {
        public MysteryMachineTaskId ConfigKey { get; set; }
        private string TaskType { get; set; }
        private List<string> TaskAux { get; set; }
        private string RewardType { get; set; }
        private string RewardId { get; set; }
        private string RewardAux0 { get; set; }
        private string RewardAux1 { get; set; }
        private int RewardAmount { get; set; }
        private bool Recurring { get; set; }
        private int RecurringIncrease { get; set; }

        public MysteryMachineTaskSource()
        {
        }
    }
}
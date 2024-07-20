using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;

namespace GameLogic.DailyTasks
{
    public class DailyTaskSource : IConfigItemSource<DailyTaskDefinition, DailyTaskId>, IGameConfigSourceItem<DailyTaskId, DailyTaskDefinition>, IHasGameConfigKey<DailyTaskId>
    {
        public DailyTaskId ConfigKey { get; set; }
        private string PoolType { get; set; }
        private int StartLevel { get; set; }
        private int EndLevel { get; set; }
        private string RequiredItemType { get; set; }
        private int RequiredAmount { get; set; }
        private string RewardItemType { get; set; }
        private int RewardAmount { get; set; }
        private string RewardAux1 { get; set; }
        private F32 InitialWeight { get; set; }

        public DailyTaskSource()
        {
        }
    }
}
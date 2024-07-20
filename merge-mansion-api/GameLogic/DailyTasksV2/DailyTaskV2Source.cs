using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.DailyTasksV2
{
    public class DailyTaskV2Source : IConfigItemSource<DailyTaskV2Info, DailyTaskV2Id>, IGameConfigSourceItem<DailyTaskV2Id, DailyTaskV2Info>, IHasGameConfigKey<DailyTaskV2Id>
    {
        public DailyTaskV2Id ConfigKey { get; set; }
        public List<int> RequirementItemValue { get; set; }
        public List<int> RewardItemValue { get; set; }
        public List<bool> RefreshEnabled { get; set; }
        public List<List<int>> RefreshCosts { get; set; }
        public List<List<string>> AlgorithmAttempts { get; set; }
        public bool IsEnabled { get; set; }
        public int StreakCountMin { get; set; }
        public int StreakCountMax { get; set; }
        public int UIOrder { get; set; }

        public DailyTaskV2Source()
        {
        }
    }
}
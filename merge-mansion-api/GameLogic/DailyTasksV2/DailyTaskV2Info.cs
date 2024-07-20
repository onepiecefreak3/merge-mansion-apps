using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTaskV2Info : IGameConfigData<DailyTaskV2Id>, IGameConfigData, IHasGameConfigKey<DailyTaskV2Id>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyTaskV2Id TaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<DailyTaskV2StepInfo> Steps { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StreakCountMin { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int StreakCountMax { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int UIOrder { get; set; }

        public DailyTaskV2Id ConfigKey => TaskId;

        public DailyTaskV2Info()
        {
        }

        public DailyTaskV2Info(DailyTaskV2Id taskId, bool isEnabled, List<DailyTaskV2StepInfo> steps, int streakCountMin, int streakCountMax, int uiOrder)
        {
        }
    }
}
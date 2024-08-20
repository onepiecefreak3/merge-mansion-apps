using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.StatsTracking;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    public class DailyScoopStandardObjectiveDataSource : IConfigItemSource<DailyScoopStandardObjectiveData, DailyScoopStandardObjectiveId>, IGameConfigSourceItem<DailyScoopStandardObjectiveId, DailyScoopStandardObjectiveData>, IHasGameConfigKey<DailyScoopStandardObjectiveId>
    {
        public DailyScoopStandardObjectiveId ConfigKey { get; set; }
        public int ObjectiveRequirement { get; set; }
        public StatsObjectiveType ObjectiveType { get; set; }
        public int OrderPriority { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        public List<string> ObjectiveParameter { get; set; }

        public DailyScoopStandardObjectiveDataSource()
        {
        }
    }
}
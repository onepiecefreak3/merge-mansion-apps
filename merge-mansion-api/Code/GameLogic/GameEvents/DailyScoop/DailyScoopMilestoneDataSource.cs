using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    public class DailyScoopMilestoneDataSource : IConfigItemSource<DailyScoopMilestoneData, DailyScoopMilestoneId>, IGameConfigSourceItem<DailyScoopMilestoneId, DailyScoopMilestoneData>, IHasGameConfigKey<DailyScoopMilestoneId>
    {
        public DailyScoopMilestoneId ConfigKey { get; set; }
        public int RequiredPoints { get; set; }
        private List<string> RewardSegment { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }

        public DailyScoopMilestoneDataSource()
        {
        }
    }
}
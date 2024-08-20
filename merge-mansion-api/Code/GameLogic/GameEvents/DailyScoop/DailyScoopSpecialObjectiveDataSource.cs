using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.StatsTracking;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    public class DailyScoopSpecialObjectiveDataSource : IConfigItemSource<DailyScoopSpecialObjectiveData, DailyScoopSpecialObjectiveId>, IGameConfigSourceItem<DailyScoopSpecialObjectiveId, DailyScoopSpecialObjectiveData>, IHasGameConfigKey<DailyScoopSpecialObjectiveId>
    {
        public DailyScoopSpecialObjectiveId ConfigKey { get; set; }
        public int ObjectiveGroup { get; set; }
        public List<int> ObjectiveRequirement { get; set; }
        public StatsObjectiveType ObjectiveType { get; set; }
        public List<string> ObjectiveParameter { get; set; }
        private List<string> Segment { get; set; }
        private List<int> GroupWeight { get; set; }
        private string DailyScoopPointsRewardType { get; set; }
        private string DailyScoopPointsRewardId { get; set; }
        private string DailyScoopPointsRewardAux0 { get; set; }
        private string DailyScoopPointsRewardAux1 { get; set; }
        private List<int> DailyScoopPointsRewardAmount { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<int> Reward0WeightSegment { get; set; }
        private List<int> Reward1WeightSegment { get; set; }
        private List<int> Reward2WeightSegment { get; set; }

        public DailyScoopSpecialObjectiveDataSource()
        {
        }
    }
}
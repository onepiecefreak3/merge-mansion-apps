using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.StatsTracking;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopSpecialObjectiveData : IGameConfigData<DailyScoopSpecialObjectiveId>, IGameConfigData, IHasGameConfigKey<DailyScoopSpecialObjectiveId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopSpecialObjectiveId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ObjectiveGroup { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> ObjectiveRequirement { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public StatsObjectiveType ObjectiveType { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<string> ObjectiveParameter { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<PlayerReward> EventPointsRewards { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<PlayerReward> SecondRewards { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> Segments { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<int> RewardWeightSegment0 { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<int> RewardWeightSegment1 { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public List<int> RewardWeightSegment2 { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public List<int> GroupWeight { get; set; }

        public DailyScoopSpecialObjectiveData()
        {
        }

        public DailyScoopSpecialObjectiveData(DailyScoopSpecialObjectiveId configKey, int objectiveGroup, List<int> objectiveRequirement, StatsObjectiveType objectiveType, List<string> objectiveParameter, List<PlayerReward> eventPointsRewards, List<PlayerReward> secondRewards, List<PlayerSegmentId> segments, List<int> rewardWeightSegment0, List<int> rewardWeightSegment1, List<int> rewardWeightSegment2, List<int> groupWeight)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopDayData : IGameConfigData<DailyScoopDayId>, IGameConfigData, IHasGameConfigKey<DailyScoopDayId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopDayId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<int> MinObjectivesPerGroup { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> SpecialObjectiveGroups { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<DailyScoopStandardObjectiveId> StandardObjectives { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> RewardSegment { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int TargetMilestone { get; set; }

        public DailyScoopDayData()
        {
        }

        public DailyScoopDayData(DailyScoopDayId configKey, List<int> minObjectivesPerGroup, List<int> specialObjectiveGroups, List<DailyScoopStandardObjectiveId> standardObjectives, List<PlayerReward> rewards, List<PlayerSegmentId> rewardSegment, int targetMilestone)
        {
        }
    }
}
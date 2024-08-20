using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using GameLogic.StatsTracking;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopSpecialStatsObjective
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopSpecialObjectiveId ObjectiveId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int SegmentIndex { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int MinimumObjectivesAmount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public StatsObjective Objective { get; set; }

        public DailyScoopSpecialStatsObjective()
        {
        }

        public DailyScoopSpecialStatsObjective(DailyScoopSpecialObjectiveId objectiveId, int segmentIndex, List<PlayerReward> rewards, int minimumObjectivesAmount, StatsObjective objective)
        {
        }
    }
}
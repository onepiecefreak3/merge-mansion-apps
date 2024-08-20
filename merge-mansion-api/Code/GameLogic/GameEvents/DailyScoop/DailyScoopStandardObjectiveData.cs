using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using GameLogic.StatsTracking;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopStandardObjectiveData : IGameConfigData<DailyScoopStandardObjectiveId>, IGameConfigData, IHasGameConfigKey<DailyScoopStandardObjectiveId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopStandardObjectiveId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ObjectiveRequirement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public StatsObjectiveType ObjectiveType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int OrderPriority { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<string> ObjectiveParameter { get; set; }

        public DailyScoopStandardObjectiveData()
        {
        }

        public DailyScoopStandardObjectiveData(DailyScoopStandardObjectiveId configKey, int objectiveRequirement, StatsObjectiveType objectiveType, int orderPriority, List<PlayerReward> rewards, List<string> objectiveParameter)
        {
        }
    }
}
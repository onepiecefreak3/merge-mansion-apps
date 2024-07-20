using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;
using GameLogic.Area;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTasksV2MergeChainInfo : IGameConfigData<MergeChainId>, IGameConfigData, IHasGameConfigKey<MergeChainId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeChainId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int? MinLevel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int? MaxLevel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool CanBeRequirement { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool CanBeReward { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public F32 RequirementMultiplier { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public F32 RewardMultiplier { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool RewardOnlyIfInHotspotRequirement { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public bool OnlyPossibleRequirementsHighPriority { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<AreaId> RewardOnlyIfHasAtLeastOneVisibleHotspotInAreas { get; set; }

        public DailyTasksV2MergeChainInfo()
        {
        }

        public DailyTasksV2MergeChainInfo(MergeChainId configKey, int? minLevel, int? maxLevel, bool canBeRequirement, bool canBeReward, F32 requirementMultiplier, F32 rewardMultiplier, bool rewardOnlyIfInHotspotRequirement, bool onlyPossibleRequirementsHighPriority, List<AreaId> rewardOnlyIfHasAtLeastOneVisibleHotspotInAreas)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTasksV2ItemBoultonLeagueInfo : IGameConfigData<ItemTypeConstant>, IGameConfigData, IHasGameConfigKey<ItemTypeConstant>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ItemTypeConstant ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool CanBeRequirement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 RequirementMultiplier { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public F32 LeaguesPoints { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public F32 XpPoints { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public F32 SoloMilestonePoints { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool OnlyPossibleRequirementsHighPriority { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> RequireOnlyIfHaveProducer { get; set; }

        public DailyTasksV2ItemBoultonLeagueInfo()
        {
        }

        public DailyTasksV2ItemBoultonLeagueInfo(ItemTypeConstant configKey, bool canBeRequirement, F32 requirementMultiplier, F32 leaguesPoints, F32 xpPoints, F32 soloMilestonePoints, bool onlyPossibleRequirementsHighPriority, List<MetaRef<ItemDefinition>> requireOnlyIfHaveProducer)
        {
        }
    }
}
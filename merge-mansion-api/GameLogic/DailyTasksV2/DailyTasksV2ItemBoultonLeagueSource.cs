using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;

namespace GameLogic.DailyTasksV2
{
    public class DailyTasksV2ItemBoultonLeagueSource : IConfigItemSource<DailyTasksV2ItemBoultonLeagueInfo, ItemTypeConstant>, IGameConfigSourceItem<ItemTypeConstant, DailyTasksV2ItemBoultonLeagueInfo>, IHasGameConfigKey<ItemTypeConstant>
    {
        public ItemTypeConstant ConfigKey { get; set; }
        public bool CanBeRequirement { get; set; }
        public F32 RequirementMultiplier { get; set; }
        public F32 LeaguesPoints { get; set; }
        public F32 XpPoints { get; set; }
        public F32 SoloMilestonePoints { get; set; }
        public bool OnlyPossibleRequirementsHighPriority { get; set; }
        public List<string> RequireOnlyIfHaveProducer { get; set; }

        public DailyTasksV2ItemBoultonLeagueSource()
        {
        }
    }
}
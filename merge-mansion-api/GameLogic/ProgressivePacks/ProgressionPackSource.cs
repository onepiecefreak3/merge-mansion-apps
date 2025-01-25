using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.StatsTracking;
using System.Collections.Generic;

namespace GameLogic.ProgressivePacks
{
    public class ProgressionPackSource : IConfigItemSource<ProgressionPack, ProgressionPackId>, IGameConfigSourceItem<ProgressionPackId, ProgressionPack>, IHasGameConfigKey<ProgressionPackId>
    {
        public int Levels;
        public ProgressionPackId ConfigKey { get; set; }
        public string FreeRewards { get; set; }
        public string PremiumRewards { get; set; }
        public string LevelRequirments { get; set; }
        public StatsObjectiveType ObjectiveType { get; set; }
        public List<string> ObjectiveParameters { get; set; }

        public ProgressionPackSource()
        {
        }
    }
}
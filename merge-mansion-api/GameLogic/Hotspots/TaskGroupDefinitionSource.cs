using Code.GameLogic.Config;
using GameLogic.Area;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Hotspots
{
    public class TaskGroupDefinitionSource : IConfigItemSource<TaskGroupDefinition, TaskGroupId>, IGameConfigSourceItem<TaskGroupId, TaskGroupDefinition>, IHasGameConfigKey<TaskGroupId>
    {
        public TaskGroupId ConfigKey { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }

        public TaskGroupDefinitionSource()
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Area;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.Hotspots
{
    [MetaSerializable]
    public class TaskGroupDefinition : IGameConfigData<TaskGroupId>, IGameConfigData, IHasGameConfigKey<TaskGroupId>
    {
        public TaskGroupId ConfigKey => Id;

        [MetaMember(1, (MetaMemberFlags)0)]
        public TaskGroupId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        public TaskGroupDefinition()
        {
        }

        public TaskGroupDefinition(TaskGroupId id, List<PlayerReward> rewards)
        {
        }
    }
}
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System.Runtime.Serialization;
using System;
using GameLogic.Player.Items;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventTaskInfo : IGameConfigData<EventTaskId>, IGameConfigData, IGameConfigKey<EventTaskId>, IValidatable
    {
        [MetaMember(1, 0)]
        public EventTaskId EventTaskId { get; set; }

        [MetaMember(2, 0)]
        public string DisplayName { get; set; }

        [MetaMember(3, 0)]
        public string Description { get; set; }

        [MetaMember(4, 0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(5, 0)]
        public List<PlayerItemRequirement> Requirements { get; set; }

        [MetaMember(6, 0)]
        public List<MetaRef<EventTaskInfo>> UnlockTaskRefs { get; set; }

        [MetaMember(7, 0)]
        public string TaskTitleLocId { get; set; }
        public EventTaskId ConfigKey => EventTaskId;

        [IgnoreDataMember]
        public IEnumerable<EventTaskInfo> UnlockTasks { get; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<IEnumerable<ItemDefinition>, int>> RequiredItems { get; }

        public EventTaskInfo()
        {
        }

        public EventTaskInfo(EventTaskId eventTaskId, string displayName, string description, List<PlayerReward> rewards, List<PlayerItemRequirement> requirements, List<MetaRef<EventTaskInfo>> unlocksTasks, string taskTitleLocId)
        {
        }
    }
}
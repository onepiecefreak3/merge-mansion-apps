using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using System.Runtime.Serialization;
using System;
using GameLogic.Player.Items;

namespace GameLogic.Player.DynamicEvents
{
    [MetaSerializable]
    public class DynamicEventTaskState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventTaskId EventTaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerItemRequirement> Requirements { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public EventTaskInfo originalEventTaskInfo { get; set; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<IEnumerable<ItemDefinition>, int>> RequiredItems { get; }

        private DynamicEventTaskState()
        {
        }

        public DynamicEventTaskState(EventTaskInfo definition, List<PlayerItemRequirement> requirements, List<PlayerReward> rewards)
        {
        }
    }
}
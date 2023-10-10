using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevelInfo : IGameConfigData<EventLevelId>, IGameConfigData, IGameConfigKey<EventLevelId>, IValidatable
    {
        [MetaMember(1, 0)]
        public EventLevelId EventLevelId { get; set; }

        [MetaMember(2, 0)]
        public int RequiredPoints { get; set; }

        [MetaMember(3, 0)]
        public List<PlayerReward> Rewards { get; set; }
        public EventLevelId ConfigKey => EventLevelId;

        public EventLevelInfo()
        {
        }

        public EventLevelInfo(EventLevelId eventLevelId, int requiredPoints, List<PlayerReward> rewards)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int? SegmentColorOverride { get; set; }

        public EventLevelInfo(EventLevelId eventLevelId, int requiredPoints, List<PlayerReward> rewards, int? segmentColorOverride)
        {
        }
    }
}
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using GameLogic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevels : IGameConfigData<EventLevelSetId>, IGameConfigData, IHasGameConfigKey<EventLevelSetId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventLevelSetId SetId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> LevelsInfos { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EventLevels.LevelProgression Progression { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int? VisibleLevels { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public EventLevels.RewardingType Rewarding { get; set; }
        public EventLevelSetId ConfigKey => SetId;

        [MetaSerializable]
        public enum LevelProgression
        {
            Linear = 0,
            Looping = 1
        }

        [MetaSerializable]
        [ForceExplicitEnumValues]
        public enum RewardingType
        {
            LevelReached = 0,
            EventEnded = 1
        }

        public EventLevels()
        {
        }

        public EventLevels(List<MetaRef<EventLevelInfo>> levelsInfo, EventLevels.LevelProgression progression)
        {
        }
    }
}
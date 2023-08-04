using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevels : IGameConfigData<EventLevelSetId>, IGameConfigData, IValidatable
    {
        [MetaMember(1, 0)]
        public EventLevelSetId SetId { get; set; }

        [MetaMember(2, 0)]
        public List<MetaRef<EventLevelInfo>> LevelsInfos { get; set; }

        [MetaMember(3, 0)]
        public LevelProgression Progression { get; set; }

        [MetaMember(4, 0)]
        public int? VisibleLevels { get; set; }

        [MetaMember(5, 0)]
        public RewardingType Rewarding { get; set; }
        public EventLevelSetId ConfigKey => SetId;

        public enum LevelProgression
        {
            Linear = 0,
            Looping = 1
        }

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
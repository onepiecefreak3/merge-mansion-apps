using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System;
using GameLogic.Player.Director.Config;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevelInfo : IGameConfigData<EventLevelId>, IGameConfigData, IHasGameConfigKey<EventLevelId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventLevelId EventLevelId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RequiredPoints { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
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

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<IDirectorAction> OnLevelClaimAction { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<EventLevelId> RequiredLevelRewards { get; set; }

        public EventLevelInfo(EventLevelId eventLevelId, int requiredPoints, List<PlayerReward> rewards, int? segmentColorOverride, List<IDirectorAction> onLevelClaimAction, List<EventLevelId> requiredLevelRewards)
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<string> Tags { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<int> PointsToTriggerAction { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<IDirectorAction> Actions { get; set; }

        public EventLevelInfo(EventLevelId eventLevelId, int requiredPoints, List<PlayerReward> rewards, int? segmentColorOverride, List<IDirectorAction> onLevelClaimAction, List<EventLevelId> requiredLevelRewards, List<string> tags, List<int> pointsToTriggerAction, List<IDirectorAction> actions)
        {
        }
    }
}
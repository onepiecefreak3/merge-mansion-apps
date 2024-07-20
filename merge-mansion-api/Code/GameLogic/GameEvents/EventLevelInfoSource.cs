using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class EventLevelInfoSource : IConfigItemSource<EventLevelInfo, EventLevelId>, IGameConfigSourceItem<EventLevelId, EventLevelInfo>, IHasGameConfigKey<EventLevelId>, IGameConfigData<EventLevelId>, IGameConfigData
    {
        private EventLevelId EventLevelId { get; set; }
        private int RequiredPoints { get; set; }
        private CurrencySource CurrencySource { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardSource { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private int? SegmentColorOverride { get; set; }
        private List<string> OnLevelClaimAction { get; set; }
        private string RequiredLevelRewards { get; set; }
        private List<string> Tags { get; set; }
        private List<int> PointsToTriggerAction { get; set; }
        private List<string> Action { get; set; }
        public EventLevelId ConfigKey { get; }

        public EventLevelInfoSource()
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Schedule;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;

namespace Code.GameLogic.GameEvents
{
    public class BoultonLeagueEventSource : IConfigItemSource<BoultonLeagueEventInfo, BoultonLeagueEventId>, IGameConfigSourceItem<BoultonLeagueEventId, BoultonLeagueEventInfo>, IHasGameConfigKey<BoultonLeagueEventId>
    {
        public BoultonLeagueEventId ConfigKey { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public EventGroupId GroupId { get; set; }
        public bool IsEnabled { get; set; }
        public BoultonLeagueMatchmakingAlgorithm MatchmakingAlgorithm { get; set; }
        public string NameLocId { get; set; }
        public MetaScheduleBase Schedule { get; set; }
        public List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        public List<MetaRef<BoultonLeagueStageInfo>> Stages { get; set; }
        public string UnlockRequirementAmount { get; set; }
        public string UnlockRequirementAux0 { get; set; }
        public string UnlockRequirementId { get; set; }
        public string UnlockRequirementType { get; set; }

        public BoultonLeagueEventSource()
        {
        }

        private string ContextCategory { get; set; }
        private string ContextSubCategory { get; set; }
    }
}
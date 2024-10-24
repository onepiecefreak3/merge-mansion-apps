using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using GameLogic.Player.Requirements;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [MetaActivableConfigData("BoultonLeagueEvent", false, true)]
    public class BoultonLeagueEventInfo : IMetaActivableConfigData<BoultonLeagueEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<BoultonLeagueEventId>, IHasGameConfigKey<BoultonLeagueEventId>, IMetaActivableInfo<BoultonLeagueEventId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public BoultonLeagueEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<MetaRef<BoultonLeagueStageInfo>> StageRefs { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public BoultonLeagueMatchmakingAlgorithm MatchmakingAlgorithm { get; set; }
        public BoultonLeagueEventId ActivableId { get; }
        public BoultonLeagueEventId ConfigKey => EventId;
        public string DisplayShortInfo { get; }

        public BoultonLeagueEventInfo()
        {
        }

        public BoultonLeagueEventInfo(BoultonLeagueEventId eventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, PlayerRequirement unlockRequirement, List<MetaRef<BoultonLeagueStageInfo>> stageRefs, EventGroupId groupId, BoultonLeagueMatchmakingAlgorithm matchmakingAlgorithm)
        {
        }
    }
}
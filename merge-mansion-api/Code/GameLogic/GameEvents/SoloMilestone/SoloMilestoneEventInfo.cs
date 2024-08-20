using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using GameLogic.Player.Requirements;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents.SoloMilestone
{
    [MetaSerializable]
    [MetaActivableConfigData("SoloMilestoneEvent", false, true)]
    public class SoloMilestoneEventInfo : IMetaActivableConfigData<SoloMilestoneEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<SoloMilestoneEventId>, IHasGameConfigKey<SoloMilestoneEventId>, IMetaActivableInfo<SoloMilestoneEventId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SoloMilestoneEventId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<SoloMilestoneMilestonesId> Milestones { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool TokenSpawnsEnabled { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string Theme { get; set; }

        [IgnoreDataMember]
        public SoloMilestoneEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        public SoloMilestoneEventInfo()
        {
        }

        public SoloMilestoneEventInfo(SoloMilestoneEventId configKey, string displayName, string description, MetaActivableParams activableParams, string nameLocId, PlayerRequirement unlockRequirement, List<SoloMilestoneMilestonesId> milestones, bool tokenSpawnsEnabled, string theme)
        {
        }
    }
}
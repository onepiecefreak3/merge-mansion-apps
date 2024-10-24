using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents.SoloMilestone
{
    public class SoloMilestoneEventInfoSource : IConfigItemSource<SoloMilestoneEventInfo, SoloMilestoneEventId>, IGameConfigSourceItem<SoloMilestoneEventId, SoloMilestoneEventInfo>, IHasGameConfigKey<SoloMilestoneEventId>
    {
        public SoloMilestoneEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string NameLocId { get; set; }
        private List<SoloMilestoneMilestonesId> Milestones { get; set; }
        private bool TokenSpawnEnabled { get; set; }
        private string Theme { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public SoloMilestoneEventInfoSource()
        {
        }

        private int Priority { get; set; }
    }
}
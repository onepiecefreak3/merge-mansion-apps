using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.StatsTracking;
using System.Collections.Generic;
using System;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;

namespace GameLogic.ProgressivePacks
{
    public class ProgressionPackEventSource : IConfigItemSource<ProgressionPackEventInfo, ProgressionPackEventId>, IGameConfigSourceItem<ProgressionPackEventId, ProgressionPackEventInfo>, IHasGameConfigKey<ProgressionPackEventId>
    {
        public ProgressionPackEventId ConfigKey { get; set; }
        public ProgressionPackId ProgressionPackId { get; set; }
        public StatsObjectiveType ObjectiveType { get; set; }
        public List<string> ObjectiveParameter { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private int Priority { get; set; }
        public string PlacementId { get; set; }
        public MetaRef<InAppProductInfo> PremiumIAP { get; set; }
        public bool UseOfferId { get; set; }
        public MetaRef<MergeMansionOfferGroupInfo> OfferGroupId { get; set; }

        public ProgressionPackEventSource()
        {
        }

        private string ContextCategory { get; set; }
        private string ContextSubCategory { get; set; }
    }
}
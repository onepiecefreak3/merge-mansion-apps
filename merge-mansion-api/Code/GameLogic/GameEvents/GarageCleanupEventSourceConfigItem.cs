using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Merge;

namespace Code.GameLogic.GameEvents
{
    public class GarageCleanupEventSourceConfigItem : IConfigItemSource<GarageCleanupEventInfo, GarageCleanupEventId>, IGameConfigSourceItem<GarageCleanupEventId, GarageCleanupEventInfo>, IHasGameConfigKey<GarageCleanupEventId>
    {
        public GarageCleanupEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private bool IsEnabled { get; set; }
        private List<string> SpawnerItem { get; set; }
        private List<GarageCleanupBoardId> Board { get; set; }
        private List<MetaRef<GarageCleanupPatternSetInfo>> PatternSet { get; set; }
        private List<int> BoardCost { get; set; }
        private List<MetaRef<GarageCleanupRewardInfo>> SlotFillReward { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private MergeBoardId MergeBoardId { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private string PrefabsOverride { get; set; }
        private bool AlwaysShowPatternsAndRewards { get; set; }
        private EventGroupId GroupId { get; set; }

        public GarageCleanupEventSourceConfigItem()
        {
        }
    }
}
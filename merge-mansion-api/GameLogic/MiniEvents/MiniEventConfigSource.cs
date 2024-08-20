using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Schedule;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;

namespace GameLogic.MiniEvents
{
    public class MiniEventConfigSource : IConfigItemSource<MiniEventInfo, MiniEventId>, IGameConfigSourceItem<MiniEventId, MiniEventInfo>, IHasGameConfigKey<MiniEventId>
    {
        public MiniEventId ConfigKey { get; }
        private MiniEventId MiniEventId { get; set; }
        private bool IsEnabled { get; set; }
        private string NameLocId { get; set; }
        private string DescLocId { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MiniEventTypeId> PropertiesAffected { get; set; }
        private List<string> RowsAffected { get; set; }
        private List<string> NewValues { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private MiniEventUIId UISchemeId { get; set; }
        private bool ShowStartPopup { get; set; }
        private bool ShowMainHubBadge { get; set; }

        public MiniEventConfigSource()
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Config;
using Metaplay.Core;
using Metaplay.Core.Schedule;
using Metaplay.Core.Player;
using System;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    public class DailyScoopEventInfoSource : IConfigItemSource<DailyScoopEventInfo, DailyScoopEventId>, IGameConfigSourceItem<DailyScoopEventId, DailyScoopEventInfo>, IHasGameConfigKey<DailyScoopEventId>
    {
        public DailyScoopEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private List<DailyScoopWeekId> WeekId { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private List<PlayerSegmentId> WeekSegments { get; set; }

        public DailyScoopEventInfoSource()
        {
        }

        private int Priority { get; set; }
    }
}
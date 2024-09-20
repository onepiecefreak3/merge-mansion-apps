using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Metaplay.Core.Player;

namespace GameLogic.Player.ScheduledActions
{
    public class ScheduledActionSource : IConfigItemSource<ScheduledActionInfo, ScheduledActionId>, IGameConfigSourceItem<ScheduledActionId, ScheduledActionInfo>, IHasGameConfigKey<ScheduledActionId>
    {
        public ScheduledActionId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private bool IsEnabled { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string Actions { get; set; }

        public ScheduledActionSource()
        {
        }
    }
}
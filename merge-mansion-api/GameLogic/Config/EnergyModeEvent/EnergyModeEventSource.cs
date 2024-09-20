using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Player.Modes;
using System.Collections.Generic;
using Metaplay.Core.Schedule;
using Metaplay.Core.Player;

namespace GameLogic.Config.EnergyModeEvent
{
    public class EnergyModeEventSource : IConfigItemSource<EnergyModeEventInfo, EnergyModeEventId>, IGameConfigSourceItem<EnergyModeEventId, EnergyModeEventInfo>, IHasGameConfigKey<EnergyModeEventId>
    {
        public EnergyModeEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private MetaRef<EnergyModeInfo> EnergyMode { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string NameLocId { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public EnergyModeEventSource()
        {
        }
    }
}
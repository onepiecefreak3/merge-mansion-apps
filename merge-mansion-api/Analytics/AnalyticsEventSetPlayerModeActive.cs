using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using System;
using GameLogic.Player.Modes;

namespace Analytics
{
    [AnalyticsEvent(182, "Set player mode active/inactive", 1, null, false, true, false)]
    public class AnalyticsEventSetPlayerModeActive : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the activated/deactivated mode")]
        [JsonProperty("player_mode_id")]
        public string PlayerModeId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("True if mode was activated, false if deactivated")]
        [JsonProperty("active")]
        public bool Active { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventSetPlayerModeActive()
        {
        }

        public AnalyticsEventSetPlayerModeActive(PlayerModeId playerModeId, bool active)
        {
        }
    }
}
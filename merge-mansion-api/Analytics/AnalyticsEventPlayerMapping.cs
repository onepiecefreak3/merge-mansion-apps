using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core;
using System;

namespace Analytics
{
    [AnalyticsEvent(161, "Player Mapping", 1, null, false, true, false)]
    public class AnalyticsEventPlayerMapping : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("player_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Real Player Id")]
        public EntityId PlayerId { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventPlayerMapping()
        {
        }

        public AnalyticsEventPlayerMapping(EntityId playerId)
        {
        }
    }
}
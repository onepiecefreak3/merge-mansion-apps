using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(145, "Garage Cleanup event level bought", 1, null, true, true, false)]
    public class AnalyticsEventGarageCleanupBuyLevel : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [Description("Garage cleanup event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Level of the board that was just bought")]
        [JsonProperty("board_level")]
        public int BoardLevel { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventGarageCleanupBuyLevel()
        {
        }

        public AnalyticsEventGarageCleanupBuyLevel(string eventId, int boardLevel)
        {
        }
    }
}
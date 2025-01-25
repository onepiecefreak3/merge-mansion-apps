using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(143, "Garage cleanup event visited", 1, null, false, true, false)]
    public class AnalyticsEventGarageCleanupEventVisited : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Garage cleanup event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [Description("Level of the board")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("board_level")]
        public int BoardLevel { get; set; }

        [Description("Where did the player go to the event popup from")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("source")]
        public string Source { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventGarageCleanupEventVisited()
        {
        }

        public AnalyticsEventGarageCleanupEventVisited(string eventId, int boardLevel, string source)
        {
        }
    }
}
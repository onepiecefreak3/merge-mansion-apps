using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(146, "Claim garage cleanup event spawner item", 1, null, false, true, false)]
    public class AnalyticsEventGarageCleanupSpawnerItemClaimed : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        [Description("Garage cleanup event id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Level of the board")]
        [JsonProperty("board_level")]
        public int BoardLevel { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventGarageCleanupSpawnerItemClaimed()
        {
        }

        public AnalyticsEventGarageCleanupSpawnerItemClaimed(string eventId, int boardLevel)
        {
        }
    }
}
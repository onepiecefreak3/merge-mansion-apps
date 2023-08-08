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

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Garage cleanup event id")]
        public string EventId { get; set; }

        [Description("Level of the board")]
        [MetaMember(2, (MetaMemberFlags)0)]
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
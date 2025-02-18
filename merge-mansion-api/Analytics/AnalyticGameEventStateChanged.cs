using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(135, "Game Event state changed", 1, null, false, true, false)]
    public class AnalyticGameEventStateChanged : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Id of event in question")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("New state for the event")]
        [JsonProperty("event_state")]
        public string State { get; set; }

        [JsonProperty("level")]
        [Description("Level associated to the event, if any")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int? Level { get; set; }
        public override string EventDescription { get; }

        public AnalyticGameEventStateChanged()
        {
        }

        public AnalyticGameEventStateChanged(string eventId, string state, int? level)
        {
        }
    }
}
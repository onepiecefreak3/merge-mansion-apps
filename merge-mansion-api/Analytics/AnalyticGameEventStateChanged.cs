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

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of event in question")]
        public string EventId { get; set; }

        [JsonProperty("event_state")]
        [Description("New state for the event")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string State { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("level")]
        [Description("Level associated to the event, if any")]
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
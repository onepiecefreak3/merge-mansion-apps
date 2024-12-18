using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(133, "Player incident", 1, null, false, true, false)]
    public class AnalyticsEventIncident : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("ID of the incident")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("incidentId")]
        public string IncidentId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("type")]
        [Description("Type of the incident (crash, recoverable, etc.)")]
        public string Type { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("subType")]
        [Description("If present, more detailed type of the incident")]
        public string SubType { get; set; }

        [Description("String describing the incident in more details (stacktrace, etc.)")]
        [JsonProperty("reason")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string Reason { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventIncident()
        {
        }

        public AnalyticsEventIncident(string incidentId, string type, string subType, string reason)
        {
        }
    }
}
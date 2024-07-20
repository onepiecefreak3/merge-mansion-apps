using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(3046, "Event ended", 1, null, false, false, true)]
    public class TriggerEventEventEnded : PlayerTriggerEvent
    {
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Ended event")]
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        private TriggerEventEventEnded()
        {
        }

        public TriggerEventEventEnded(IStringId eventId)
        {
        }
    }
}
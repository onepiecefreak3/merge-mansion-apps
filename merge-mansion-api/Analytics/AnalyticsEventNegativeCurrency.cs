using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(105, "Negative currency", 1, null, false, true, false)]
    public class AnalyticsEventNegativeCurrency : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [Description("Item that has been taken from player")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [JsonProperty("info_type", DefaultValueHandling = (DefaultValueHandling)0)]
        public string InfoType { get; }
        public override string EventDescription { get; }

        public AnalyticsEventNegativeCurrency()
        {
        }
    }
}
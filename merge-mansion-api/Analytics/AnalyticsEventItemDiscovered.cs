using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(117, "Item discovered first time", 1, null, true, true, false)]
    public class AnalyticsEventItemDiscovered : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaOnMemberDeserializationFailure("FixItemType")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Discovered item")]
        public string ItemName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemDiscovered()
        {
        }

        public AnalyticsEventItemDiscovered(string itemName)
        {
        }
    }
}
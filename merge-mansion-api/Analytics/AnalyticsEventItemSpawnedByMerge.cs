using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(196, "Item spawned by merge", 1, null, false, true, false)]
    public class AnalyticsEventItemSpawnedByMerge : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("The item that was spawned from a merge")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [Description("Type of merge that caused the item to spawn")]
        [JsonProperty("origin_type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string OriginType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("The item that was merged to spawn the new item")]
        [JsonProperty("origin_item_name")]
        public string OriginItemName { get; set; }

        [JsonProperty("in_bubble")]
        [Description("Whether the item was spawned in a bubble")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool InBubble { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemSpawnedByMerge()
        {
        }

        public AnalyticsEventItemSpawnedByMerge(string itemName, string originType, string originItemName, bool inBubble)
        {
        }
    }
}
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

        [Description("The item that was spawned from a merge")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [Description("Type of merge that caused the item to spawn")]
        [JsonProperty("origin_type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string OriginType { get; set; }

        [JsonProperty("origin_item_name")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("The item that was merged to spawn the new item")]
        public string OriginItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Whether the item was spawned in a bubble")]
        [JsonProperty("in_bubble")]
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
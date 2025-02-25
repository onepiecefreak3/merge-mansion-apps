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
        [JsonProperty("item_name")]
        [Description("The item that was spawned from a merge")]
        public string ItemName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("origin_type")]
        [Description("Type of merge that caused the item to spawn")]
        public string OriginType { get; set; }

        [JsonProperty("origin_item_name")]
        [Description("The item that was merged to spawn the new item")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string OriginItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("in_bubble")]
        [Description("Whether the item was spawned in a bubble")]
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
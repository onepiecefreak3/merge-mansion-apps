using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(152, "Progression event item collected", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class AnalyticsEventProgressionEventItemCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Event where progress was made")]
        public string EventId { get; set; }

        [Description("Board where event item was collected")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        public MergeBoardId BoardId { get; set; }

        [JsonProperty("event_progress_gained")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How many points player made")]
        public int EventProgressGained { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("from_inventory")]
        [Description("True if item was collected from inventory")]
        public bool FromInventory { get; set; }

        [JsonProperty("item_name")]
        [Description("Collected item")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string ItemType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventProgressionEventItemCollected()
        {
        }

        public AnalyticsEventProgressionEventItemCollected(IStringId eventId, MergeBoardId boardId, int eventProgressGained, bool fromInventory, string itemType)
        {
        }

        [JsonProperty("item_level")]
        [Description("Item level")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int ItemLevel { get; set; }

        [JsonProperty("item_mergechain_total_length")]
        [Description("Merge chain total length of the item")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int ItemMergeChainTotalLength { get; set; }

        [JsonProperty("item_mergechain_unlocked_length")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the item")]
        public int ItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventProgressionEventItemCollected(IStringId eventId, MergeBoardId boardId, int eventProgressGained, bool fromInventory, string itemType, int itemLevel, int itemMergeChainTotalLength, int itemMergeChainUnlockedLength)
        {
        }
    }
}
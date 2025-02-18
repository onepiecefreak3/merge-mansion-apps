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
    [AnalyticsEventKeywords(new string[] { "event", "task" })]
    public class AnalyticsEventProgressionEventItemCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Event where progress was made")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        [Description("Board where event item was collected")]
        public MergeBoardId BoardId { get; set; }

        [JsonProperty("event_progress_gained")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How many points player made")]
        public int EventProgressGained { get; set; }

        [JsonProperty("from_inventory")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("True if item was collected from inventory")]
        public bool FromInventory { get; set; }

        [JsonProperty("item_name")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Collected item")]
        public string ItemType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventProgressionEventItemCollected()
        {
        }

        public AnalyticsEventProgressionEventItemCollected(IStringId eventId, MergeBoardId boardId, int eventProgressGained, bool fromInventory, string itemType)
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("item_level")]
        [Description("Item level")]
        public int ItemLevel { get; set; }

        [JsonProperty("item_mergechain_total_length")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the item")]
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
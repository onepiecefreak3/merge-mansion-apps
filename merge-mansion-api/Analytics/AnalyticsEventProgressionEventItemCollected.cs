using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using Metaplay.Core;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1 })]
    [AnalyticsEvent(152, "Progression event item collected", 1, null, true, true, false)]
    public class AnalyticsEventProgressionEventItemCollected : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        [Description("Event where progress was made")]
        public string EventId { get; set; }

        [JsonProperty("board_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Board where event item was collected")]
        public MergeBoardId BoardId { get; set; }

        [Description("How many points player made")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("event_progress_gained")]
        public int EventProgressGained { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("True if item was collected from inventory")]
        [JsonProperty("from_inventory")]
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

        [JsonProperty("item_level")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Item level")]
        public int ItemLevel { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("item_mergechain_total_length")]
        [Description("Merge chain total length of the item")]
        public int ItemMergeChainTotalLength { get; set; }

        [JsonProperty("item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the item")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int ItemMergeChainUnlockedLength { get; set; }

        public AnalyticsEventProgressionEventItemCollected(IStringId eventId, MergeBoardId boardId, int eventProgressGained, bool fromInventory, string itemType, int itemLevel, int itemMergeChainTotalLength, int itemMergeChainUnlockedLength)
        {
        }
    }
}
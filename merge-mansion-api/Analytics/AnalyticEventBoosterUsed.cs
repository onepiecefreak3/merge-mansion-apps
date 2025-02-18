using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using Merge;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace Analytics
{
    [AnalyticsEvent(136, "Booster/Bonus item used", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "item", "booster" })]
    public class AnalyticEventBoosterUsed : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Board where the Booster was used")]
        [JsonProperty("board_id")]
        public MergeBoardId BoardId { get; set; }

        [Description("Boosters duration")]
        [JsonProperty("duration_in_minutes")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public double Duration { get; set; }

        [Description("Boosters target item")]
        [JsonProperty("target_item")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        public string TargetItem { get; set; }

        [JsonProperty("source_item")]
        [Description("Boosters target item")]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string SourceItem { get; set; }

        [JsonProperty("from_inventory")]
        [Description("True if item was used from inventory")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool FromInventory { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventBoosterUsed()
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, MetaDuration duration, bool fromInventory)
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, string targetItem, bool fromInventory)
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, string targetItem, MetaDuration duration)
        {
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Target item level")]
        [JsonProperty("target_item_level")]
        public int TargetItemLevel { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("target_item_mergechain_total_length")]
        [Description("Merge chain total length of the target item")]
        public int TargetItemMergeChainTotalLength { get; set; }

        [JsonProperty("target_item_mergechain_unlocked_length")]
        [Description("Merge chain unlocked length of the target item")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int TargetItemMergeChainUnlockedLength { get; set; }

        [Description("Source item level")]
        [JsonProperty("source_item_level")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int SourceItemLevel { get; set; }

        [JsonProperty("source_item_mergechain_total_length")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Merge chain total length of the source item")]
        public int SourceItemMergeChainTotalLength { get; set; }

        [JsonProperty("source_item_mergechain_unlocked_length")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the source item")]
        public int SourceItemMergeChainUnlockedLength { get; set; }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, MetaDuration duration, bool fromInventory, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength)
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, string targetItem, bool fromInventory, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength)
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, string targetItem, bool fromInventory, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength, int targetItemLevel, int targetItemMergeChainTotalLength, int targetItemMergeChainUnlockedLength)
        {
        }

        public AnalyticEventBoosterUsed(string sourceItem, MergeBoardId boardId, string targetItem, MetaDuration duration, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength, int targetItemLevel, int targetItemMergeChainTotalLength, int targetItemMergeChainUnlockedLength)
        {
        }

        public override IEnumerable<string> KeywordsForEventInstance { get; }
    }
}
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using Merge;
using System.Collections.Generic;
using GameLogic.Player;
using GameLogic.Player.Items;

namespace Analytics
{
    [AnalyticsEvent(173, "Item sink", 1, null, false, true, false)]
    public class AnalyticsEventItemSink : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("source_item")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Item that was sinked")]
        public string SourceItem { get; set; }

        [JsonProperty("target_item")]
        [Description("Item that source_item was sinked into")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string TargetItem { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Id of the board where the item was sinked")]
        [JsonProperty("context")]
        public MergeBoardId MergeBoardId { get; set; }

        [JsonProperty("sink_status_multi")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Sink status for FactoryType=Multi")]
        public Dictionary<string, ItemSinkProgressStatus> SinkStatusMulti { get; set; }

        [JsonProperty("sink_status_simple")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Sink status for FactoryType=Simple/Single")]
        public SimpleSinkProgressStatus SinkStatusSimple { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemSink()
        {
        }

        public AnalyticsEventItemSink(IPlayer player, MergeItem sourceItem, MergeItem targetItem, MergeBoardId mergeBoardId)
        {
        }

        private AnalyticsEventItemSink(string sourceItem, string targetItem, MergeBoardId mergeBoardId, Dictionary<string, ItemSinkProgressStatus> sinkStatusMulti, SimpleSinkProgressStatus sinkStatusSimple)
        {
        }

        [Description("Source item level")]
        [JsonProperty("source_item_level")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int SourceItemLevel { get; set; }

        [JsonProperty("source_item_mergechain_total_length")]
        [Description("Merge chain total length of the source item")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int SourceItemMergeChainTotalLength { get; set; }

        [JsonProperty("source_item_mergechain_unlocked_length")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the source item")]
        public int SourceItemMergeChainUnlockedLength { get; set; }

        [Description("Target item level")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("target_item_level")]
        public int TargetItemLevel { get; set; }

        [Description("Merge chain total length of the target item")]
        [JsonProperty("target_item_mergechain_total_length")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public int TargetItemMergeChainTotalLength { get; set; }

        [JsonProperty("target_item_mergechain_unlocked_length")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length of the target item")]
        public int TargetItemMergeChainUnlockedLength { get; set; }

        private AnalyticsEventItemSink(string sourceItem, string targetItem, MergeBoardId mergeBoardId, Dictionary<string, ItemSinkProgressStatus> sinkStatusMulti, SimpleSinkProgressStatus sinkStatusSimple, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength, int targetItemLevel, int targetItemMergeChainTotalLength, int targetItemMergeChainUnlockedLength)
        {
        }

        [JsonProperty("target_item_sink_type")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Target Item SinkType")]
        public string TargetItemSinkType { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("SinkTag of source item")]
        [JsonProperty("source_item_tag")]
        public string SourceItemSinkTag { get; set; }

        [JsonProperty("source_item_points")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("How many points is the item worth")]
        public int SourceItemSinkPoints { get; set; }

        [JsonProperty("target_item_points")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("How many points in total are currently in target item")]
        public int TargetItemSinkPoints { get; set; }

        [JsonProperty("order_item_phase")]
        [Description("What phase is order item in")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public string OrderItemPhase { get; set; }

        [Description("Current order index")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("order_index")]
        public int OrderIndex { get; set; }

        [Description("Was order completed?")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("is_order_completed")]
        public bool IsOrderCompleted { get; set; }

        private AnalyticsEventItemSink(string sourceItem, string targetItem, MergeBoardId mergeBoardId, Dictionary<string, ItemSinkProgressStatus> sinkStatusMulti, SimpleSinkProgressStatus sinkStatusSimple, int sourceItemLevel, int sourceItemMergeChainTotalLength, int sourceItemMergeChainUnlockedLength, int targetItemLevel, int targetItemMergeChainTotalLength, int targetItemMergeChainUnlockedLength, int targetItemSinkPoints)
        {
        }
    }
}
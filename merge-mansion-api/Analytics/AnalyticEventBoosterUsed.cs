using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using Merge;
using System;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(136, "Booster/Bonus item used", 1, null, true, true, false)]
    public class AnalyticEventBoosterUsed : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Board where the Booster was used")]
        [JsonProperty("board_id")]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("duration_in_minutes")]
        [Description("Boosters duration")]
        public double Duration { get; set; }

        [MetaOnMemberDeserializationFailure("FixItemType")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("target_item")]
        [Description("Boosters target item")]
        public string TargetItem { get; set; }

        [JsonProperty("source_item")]
        [Description("Boosters target item")]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string SourceItem { get; set; }

        [JsonProperty("from_inventory")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("True if item was used from inventory")]
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
    }
}
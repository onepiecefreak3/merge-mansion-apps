using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Merge;
using System;
using GameLogic.Player.Items;

namespace Analytics
{
    [AnalyticsEvent(201, "Sink item transformed by completion", 1, null, false, true, false)]
    public class AnalyticsEventItemSinkTransform : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("context")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the board where the item was sinked")]
        public MergeBoardId MergeBoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Source item SinkType")]
        [JsonProperty("source_item_sink_type")]
        public string SourceItemSinkType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Name of the item sink transformed into")]
        [JsonProperty("item_name")]
        public string NewItemName { get; set; }

        [Description("Original sink item name")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("origin_item_name")]
        public string OriginItemName { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("total_points")]
        [Description("If sink item required points, then how many points were in the original sink item")]
        public int TotalPoints { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("was_order_item")]
        [Description("True if original item was Order item")]
        public bool WasOrderItem { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventItemSinkTransform()
        {
        }

        public AnalyticsEventItemSinkTransform(MergeItem originItem, MergeItem newItem, MergeBoardId mergeBoardId)
        {
        }
    }
}
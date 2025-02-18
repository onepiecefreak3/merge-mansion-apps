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

        [Description("Id of the board where the item was sinked")]
        [JsonProperty("context")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId MergeBoardId { get; set; }

        [Description("Source item SinkType")]
        [JsonProperty("source_item_sink_type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string SourceItemSinkType { get; set; }

        [JsonProperty("item_name")]
        [Description("Name of the item sink transformed into")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string NewItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("origin_item_name")]
        [Description("Original sink item name")]
        public string OriginItemName { get; set; }

        [Description("If sink item required points, then how many points were in the original sink item")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("total_points")]
        public int TotalPoints { get; set; }

        [Description("True if original item was Order item")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("was_order_item")]
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
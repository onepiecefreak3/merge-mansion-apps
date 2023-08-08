using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3 })]
    [AnalyticsEvent(107, "Bubble purchased", 1, null, false, true, false)]
    public class AnalyticsEventBubblePurchased : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Item inside the bubble that was bought")]
        public string ItemInBubble { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("bubble_cost")]
        [Description("How many diamonds the bubble costs")]
        public int BubbleCostInDiamonds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        [Description("Merge Board Id")]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBubblePurchased()
        {
        }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId)
        {
        }
    }
}
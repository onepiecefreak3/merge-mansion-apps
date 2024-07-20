using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 2 })]
    [AnalyticsEvent(102, "Bubble expired", 1, null, false, true, false)]
    public class AnalyticsEventBubbleExpired : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Item that was in the expired bubble")]
        public string ItemInBubble { get; set; }

        [JsonProperty("bubble_cost")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How much the bubble popping cost in diamonds")]
        public int BubbleCostInDiamonds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("dismissed")]
        [Description("Was the bubble dismissed")]
        public bool Dismissed { get; set; }

        [JsonProperty("board_id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Merge Board Id")]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBubbleExpired()
        {
        }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, bool dismissed)
        {
        }
    }
}
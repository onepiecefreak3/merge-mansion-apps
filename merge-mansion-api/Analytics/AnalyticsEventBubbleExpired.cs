using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using System.Collections.Generic;

namespace Analytics
{
    [AnalyticsEvent(102, "Bubble expired", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 2, 6, 7, 9, 10 })]
    public class AnalyticsEventBubbleExpired : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Item that was in the expired bubble")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public string ItemInBubble { get; set; }

        [Description("How much the bubble popping cost in diamonds")]
        [JsonProperty("bubble_cost")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int BubbleCostInDiamonds { get; set; }

        [JsonProperty("dismissed")]
        [Description("Was the bubble dismissed")]
        [MetaMember(4, (MetaMemberFlags)0)]
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

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Attachments to the bubble")]
        [JsonProperty("attachments")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public Dictionary<string, int> Attachment { get; set; }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool dismissed)
        {
        }

        [JsonProperty("active_ads")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Is there and Active ads on the bubble")]
        public bool IsActiveAds { get; set; }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool isActiveAds, bool dismissed)
        {
        }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, Dictionary<string, int> attachment, bool isActiveAds, bool dismissed)
        {
        }
    }
}
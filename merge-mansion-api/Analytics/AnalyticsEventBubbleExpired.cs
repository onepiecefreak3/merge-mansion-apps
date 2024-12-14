using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using System.Collections.Generic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 2, 6, 7, 9, 10 })]
    [AnalyticsEvent(102, "Bubble expired", 1, null, false, true, false)]
    public class AnalyticsEventBubbleExpired : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [Description("Item that was in the expired bubble")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemInBubble { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("How much the bubble popping cost in diamonds")]
        [JsonProperty("bubble_cost")]
        public int BubbleCostInDiamonds { get; set; }

        [Description("Was the bubble dismissed")]
        [JsonProperty("dismissed")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool Dismissed { get; set; }

        [JsonProperty("board_id")]
        [Description("Merge Board Id")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBubbleExpired()
        {
        }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, bool dismissed)
        {
        }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("attachments")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Attachments to the bubble")]
        public Dictionary<string, int> Attachment { get; set; }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool dismissed)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Is there and Active ads on the bubble")]
        [JsonProperty("active_ads")]
        public bool IsActiveAds { get; set; }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool isActiveAds, bool dismissed)
        {
        }

        public AnalyticsEventBubbleExpired(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, Dictionary<string, int> attachment, bool isActiveAds, bool dismissed)
        {
        }
    }
}
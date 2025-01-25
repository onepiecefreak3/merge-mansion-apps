using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;
using System.Collections.Generic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3, 5, 6, 9, 10 })]
    [AnalyticsEvent(107, "Bubble purchased", 1, null, false, true, false)]
    public class AnalyticsEventBubblePurchased : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Item inside the bubble that was bought")]
        public string ItemInBubble { get; set; }

        [JsonProperty("bubble_cost")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("How many diamonds the bubble costs")]
        public int BubbleCostInDiamonds { get; set; }

        [Description("Merge Board Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBubblePurchased()
        {
        }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId)
        {
        }

        [MetaMember(11, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [Description("Attachments to the bubble")]
        [JsonProperty("attachments")]
        public Dictionary<string, int> Attachment { get; set; }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount)
        {
        }

        [JsonProperty("active_ads")]
        [Description("Is there and Active ads on the bubble")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public bool IsActiveAds { get; set; }

        [JsonProperty("purchased_with_ads")]
        [Description("Was the bubble purchased with an ad")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public bool PurchasedWithAds { get; set; }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool isActiveAds, bool purchasedWithAds)
        {
        }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, Dictionary<string, int> attachment, bool isActiveAds, bool purchasedWithAds)
        {
        }
    }
}
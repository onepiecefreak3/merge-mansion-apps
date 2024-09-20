using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Merge;

namespace Analytics
{
    [AnalyticsEvent(107, "Bubble purchased", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 3 })]
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

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("attachment")]
        [Description("Attachment to the bubble")]
        public string Attachment { get; set; }

        [JsonProperty("attachment_amount")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Attachment amount")]
        public int AttachmentAmount { get; set; }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount)
        {
        }

        [JsonProperty("ActiveAds")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Is there and Active ads on the bubble")]
        public bool IsActiveAds { get; set; }

        [JsonProperty("PurchasedWithAds")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Was the bubble purchased with an ad")]
        public bool PurchasedWithAds { get; set; }

        public AnalyticsEventBubblePurchased(string itemInBubble, int bubbleCostInDiamonds, MergeBoardId boardId, string attachment, int attachmentAmount, bool isActiveAds, bool purchasedWithAds)
        {
        }
    }
}
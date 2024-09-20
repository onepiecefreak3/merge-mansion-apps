using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(187, "Rewarded ad started", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class AnalyticsEventAdStarted : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Auction Id")]
        [JsonProperty("auction_id")]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdStarted()
        {
        }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("item_diamond_price")]
        [Description("Item Diamond value")]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }
    }
}
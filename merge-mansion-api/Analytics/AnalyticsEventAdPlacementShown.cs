using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(186, "Rewarded ad placement shown", 1, null, true, true, false)]
    public class AnalyticsEventAdPlacementShown : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Ad placement")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [Description("Auction Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdPlacementShown()
        {
        }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("item_diamond_price")]
        [Description("Item Diamond value")]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }
    }
}
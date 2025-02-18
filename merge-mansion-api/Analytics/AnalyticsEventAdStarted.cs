using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(187, "Rewarded ad started", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class AnalyticsEventAdStarted : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Ad placement")]
        [JsonProperty("ad_placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdStarted()
        {
        }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId)
        {
        }

        [JsonProperty("item_diamond_price")]
        [Description("Item Diamond value")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }

        [Description("Item cost value")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value_type")]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Advertiser Id")]
        [JsonProperty("advertiser_id")]
        public string AdvertiserId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Ad Network")]
        [JsonProperty("ad_network")]
        public string NetworkId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        [Description("Amount of time skipped for a producer")]
        public string TimeSkippedAmount { get; set; }

        [Description("Diamond value of time skipped")]
        [JsonProperty("time_skipped_diamond_value")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int TimeSkippedDiamondValue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, string advertiserId, string networkId, AnalyticsContext analyticsContext)
        {
        }
    }
}
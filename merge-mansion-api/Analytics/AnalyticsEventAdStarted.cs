using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 3 })]
    [AnalyticsEvent(187, "Rewarded ad started", 1, null, true, true, false)]
    public class AnalyticsEventAdStarted : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string AdPlacement { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Item name")]
        public string ItemName { get; set; }

        [Description("Auction Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdStarted()
        {
        }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId)
        {
        }

        [JsonProperty("item_diamond_price")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Item Diamond value")]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Item cost value")]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [JsonProperty("item_cost_value_type")]
        [Description("Item cost value type")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public Currencies ItemCostValueType { get; set; }

        [Description("Advertiser Id")]
        [JsonProperty("advertiser_id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string AdvertiserId { get; set; }

        [Description("Ad Network")]
        [JsonProperty("ad_network")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string NetworkId { get; set; }

        [Description("Amount of time skipped for a producer")]
        [JsonProperty("time_skipped_amount")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public string TimeSkippedAmount { get; set; }

        [Description("Diamond value of time skipped")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_diamond_value")]
        public int TimeSkippedDiamondValue { get; set; }

        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, string advertiserId, string networkId, AnalyticsContext analyticsContext)
        {
        }
    }
}
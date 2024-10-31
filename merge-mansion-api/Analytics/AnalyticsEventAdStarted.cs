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

        [Description("Item cost value")]
        [JsonProperty("item_cost_value")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int ItemCostValue { get; set; }

        [JsonProperty("item_cost_value_type")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [JsonProperty("advertiser_id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Advertiser Id")]
        public string AdvertiserId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("network_id")]
        [Description("Network Id")]
        public string NetworkId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Amount of time skipped for a producer")]
        [JsonProperty("time_skipped_amount")]
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
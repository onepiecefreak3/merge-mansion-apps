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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Item name")]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        [Description("Auction Id")]
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

        [JsonProperty("item_cost_value_type")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("advertiser_id")]
        [Description("Advertiser Id")]
        public string AdvertiserId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        [Description("Ad Network")]
        public string NetworkId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Amount of time skipped for a producer")]
        [JsonProperty("time_skipped_amount")]
        public string TimeSkippedAmount { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_diamond_value")]
        [Description("Diamond value of time skipped")]
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
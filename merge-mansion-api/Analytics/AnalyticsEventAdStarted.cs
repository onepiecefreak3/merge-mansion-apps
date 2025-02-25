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

        [Description("Ad placement")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [JsonProperty("auction_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
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
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("advertiser_id")]
        [Description("Advertiser Id")]
        public string AdvertiserId { get; set; }

        [Description("Ad Network")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        public string NetworkId { get; set; }

        [Description("Amount of time skipped for a producer")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        public string TimeSkippedAmount { get; set; }

        [Description("Diamond value of time skipped")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_diamond_value")]
        public int TimeSkippedDiamondValue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, string advertiserId, string networkId, AnalyticsContext analyticsContext)
        {
        }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("required_items")]
        [Description("Required task items")]
        public string RequiredTaskItems { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("required_merge_chain")]
        [Description("Required merge chain")]
        public string RequiredMergeChains { get; set; }

        public AnalyticsEventAdStarted(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, string advertiserId, string networkId, AnalyticsContext analyticsContext, string requiredTaskItems, string requiredMergeChain)
        {
        }
    }
}
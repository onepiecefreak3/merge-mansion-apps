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
    [AnalyticsEvent(188, "Rewarded ad finished", 1, null, true, true, false)]
    public class AnalyticsEventAdFinished : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("ad_placement")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [Description("Auction Id")]
        [JsonProperty("auction_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Ad unit")]
        [JsonProperty("ad_unit")]
        public string AdUnit { get; set; }

        [Description("Ad network")]
        [JsonProperty("ad_network")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string AdNetwork { get; set; }

        [JsonProperty("instance_name")]
        [Description("Instance name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string InstanceName { get; set; }

        [JsonProperty("instance_id")]
        [Description("Instance Id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string InstanceId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("country")]
        [Description("Country")]
        public string Country { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("revenue")]
        [Description("Revenue")]
        public double Revenue { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Lifetime revenue")]
        [JsonProperty("lifetime_revenue")]
        public double LifetimeRevenue { get; set; }

        [JsonProperty("precision")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Precision")]
        public string Precision { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Segment name")]
        [JsonProperty("segment_name")]
        public string SegmentName { get; set; }

        [Description("Encrypted CPM")]
        [JsonProperty("encrypted_cpm")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public string EncryptedCpm { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdFinished()
        {
        }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm)
        {
        }

        [JsonProperty("item_diamond_price")]
        [Description("Item Diamond value")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue)
        {
        }

        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Item cost value")]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [Description("Item cost value type")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value_type")]
        public Currencies ItemCostValueType { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        [Description("Amount of time skipped for a producer")]
        public string TimeSkippedAmount { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_diamond_value")]
        [Description("Diamond value of time skipped")]
        public int TimeSkippedDiamondValue { get; set; }

        [Description("Remaining time for producer")]
        [JsonProperty("time_remaining_amount")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }

        [Description("Required task items")]
        [JsonProperty("required_items")]
        [MetaMember(21, (MetaMemberFlags)0)]
        public string RequiredTaskItems { get; set; }

        [Description("Required merge chain")]
        [JsonProperty("required_merge_chain")]
        [MetaMember(22, (MetaMemberFlags)0)]
        public string RequiredMergeChains { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext, string requiredTaskItems, string requiredMergeChains)
        {
        }
    }
}
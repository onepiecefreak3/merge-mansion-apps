using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(188, "Rewarded ad finished", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class AnalyticsEventAdFinished : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Item name")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        public string AuctionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("ad_unit")]
        [Description("Ad unit")]
        public string AdUnit { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        [Description("Ad network")]
        public string AdNetwork { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("instance_name")]
        [Description("Instance name")]
        public string InstanceName { get; set; }

        [JsonProperty("instance_id")]
        [Description("Instance Id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string InstanceId { get; set; }

        [Description("Country")]
        [JsonProperty("country")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string Country { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("revenue")]
        [Description("Revenue")]
        public double Revenue { get; set; }

        [JsonProperty("lifetime_revenue")]
        [Description("Lifetime revenue")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public double LifetimeRevenue { get; set; }

        [JsonProperty("precision")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Precision")]
        public string Precision { get; set; }

        [Description("Segment name")]
        [JsonProperty("segment_name")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public string SegmentName { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("encrypted_cpm")]
        [Description("Encrypted CPM")]
        public string EncryptedCpm { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdFinished()
        {
        }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm)
        {
        }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Item Diamond value")]
        [JsonProperty("item_diamond_price")]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue)
        {
        }

        [JsonProperty("item_cost_value")]
        [Description("Item cost value")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public int ItemCostValue { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value_type")]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [Description("Amount of time skipped for a producer")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        public string TimeSkippedAmount { get; set; }

        [Description("Diamond value of time skipped")]
        [JsonProperty("time_skipped_diamond_value")]
        [MetaMember(19, (MetaMemberFlags)0)]
        public int TimeSkippedDiamondValue { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }
    }
}
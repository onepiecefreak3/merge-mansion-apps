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

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [Description("Item name")]
        [JsonProperty("item_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        public string AuctionId { get; set; }

        [Description("Ad unit")]
        [JsonProperty("ad_unit")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string AdUnit { get; set; }

        [JsonProperty("ad_network")]
        [Description("Ad network")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public string AdNetwork { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("instance_name")]
        [Description("Instance name")]
        public string InstanceName { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("instance_id")]
        [Description("Instance Id")]
        public string InstanceId { get; set; }

        [JsonProperty("country")]
        [Description("Country")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string Country { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("revenue")]
        [Description("Revenue")]
        public double Revenue { get; set; }

        [Description("Lifetime revenue")]
        [JsonProperty("lifetime_revenue")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public double LifetimeRevenue { get; set; }

        [JsonProperty("precision")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Precision")]
        public string Precision { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("segment_name")]
        [Description("Segment name")]
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

        [Description("Item Diamond value")]
        [JsonProperty("item_diamond_price")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue)
        {
        }

        [Description("Item cost value")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [Description("Item cost value type")]
        [JsonProperty("item_cost_value_type")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public Currencies ItemCostValueType { get; set; }

        [Description("Amount of time skipped for a producer")]
        [JsonProperty("time_skipped_amount")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public string TimeSkippedAmount { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Diamond value of time skipped")]
        [JsonProperty("time_skipped_diamond_value")]
        public int TimeSkippedDiamondValue { get; set; }

        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }
    }
}
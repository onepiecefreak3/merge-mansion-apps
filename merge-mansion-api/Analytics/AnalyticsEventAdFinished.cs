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

        [Description("Ad placement")]
        [JsonProperty("ad_placement")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string AdPlacement { get; set; }

        [JsonProperty("item_name")]
        [Description("Item name")]
        [MetaMember(2, (MetaMemberFlags)0)]
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

        [Description("Instance name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("instance_name")]
        public string InstanceName { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("instance_id")]
        [Description("Instance Id")]
        public string InstanceId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("country")]
        [Description("Country")]
        public string Country { get; set; }

        [JsonProperty("revenue")]
        [Description("Revenue")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public double Revenue { get; set; }

        [JsonProperty("lifetime_revenue")]
        [Description("Lifetime revenue")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public double LifetimeRevenue { get; set; }

        [Description("Precision")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("precision")]
        public string Precision { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("segment_name")]
        [Description("Segment name")]
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

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value")]
        [Description("Item cost value")]
        public int ItemCostValue { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value_type")]
        [Description("Item cost value type")]
        public Currencies ItemCostValueType { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        [Description("Amount of time skipped for a producer")]
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
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
        [Description("Ad placement")]
        [JsonProperty("ad_placement")]
        public string AdPlacement { get; set; }

        [JsonProperty("item_name")]
        [Description("Item name")]
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

        [JsonProperty("ad_network")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Ad network")]
        public string AdNetwork { get; set; }

        [Description("Instance name")]
        [JsonProperty("instance_name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string InstanceName { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Instance Id")]
        [JsonProperty("instance_id")]
        public string InstanceId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("country")]
        [Description("Country")]
        public string Country { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("revenue")]
        [Description("Revenue")]
        public double Revenue { get; set; }

        [Description("Lifetime revenue")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("lifetime_revenue")]
        public double LifetimeRevenue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Precision")]
        [JsonProperty("precision")]
        public string Precision { get; set; }

        [Description("Segment name")]
        [JsonProperty("segment_name")]
        [MetaMember(13, (MetaMemberFlags)0)]
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

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value")]
        [Description("Item cost value")]
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

        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("time_remaining_amount")]
        [Description("Remaining time for producer")]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdFinished(string adPlacement, string itemName, string auctionId, string adUnit, string adNetwork, string instanceName, string instanceId, string country, double revenue, double lifetimeRevenue, string precision, string segmentName, string encryptedCpm, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }
    }
}
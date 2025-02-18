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

        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("ad_unit")]
        [Description("Ad unit")]
        public string AdUnit { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        [Description("Ad network")]
        public string AdNetwork { get; set; }

        [JsonProperty("instance_name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Instance name")]
        public string InstanceName { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Instance Id")]
        [JsonProperty("instance_id")]
        public string InstanceId { get; set; }

        [JsonProperty("country")]
        [Description("Country")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string Country { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("revenue")]
        [Description("Revenue")]
        public double Revenue { get; set; }

        [JsonProperty("lifetime_revenue")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Lifetime revenue")]
        public double LifetimeRevenue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("precision")]
        [Description("Precision")]
        public string Precision { get; set; }

        [Description("Segment name")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("segment_name")]
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

        [Description("Item Diamond value")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("item_diamond_price")]
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
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_amount")]
        public string TimeSkippedAmount { get; set; }

        [Description("Diamond value of time skipped")]
        [JsonProperty("time_skipped_diamond_value")]
        [MetaMember(19, (MetaMemberFlags)0)]
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
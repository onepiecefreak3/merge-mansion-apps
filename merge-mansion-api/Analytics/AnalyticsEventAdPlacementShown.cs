using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using GameLogic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(186, "Rewarded ad placement shown", 1, null, true, true, false)]
    public class AnalyticsEventAdPlacementShown : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [JsonProperty("item_name")]
        [Description("Item name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [Description("Auction Id")]
        [JsonProperty("auction_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdPlacementShown()
        {
        }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId)
        {
        }

        [Description("Item Diamond value")]
        [JsonProperty("item_diamond_price")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Item cost value")]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [JsonProperty("item_cost_value_type")]
        [Description("Item cost value type")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public Currencies ItemCostValueType { get; set; }

        [JsonProperty("time_skipped_amount")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Amount of time skipped for a producer")]
        public string TimeSkippedAmount { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("time_skipped_diamond_value")]
        [Description("Diamond value of time skipped")]
        public int TimeSkippedDiamondValue { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Remaining time for producer")]
        [JsonProperty("time_remaining_amount")]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }
    }
}
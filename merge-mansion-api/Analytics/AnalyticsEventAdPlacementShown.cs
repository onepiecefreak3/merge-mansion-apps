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

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Item name")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        public string AuctionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdPlacementShown()
        {
        }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("item_diamond_price")]
        [Description("Item Diamond value")]
        public int ItemDiamondValue { get; set; }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId, int itemDiamondValue)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Item cost value")]
        [JsonProperty("item_cost_value")]
        public int ItemCostValue { get; set; }

        [Description("Item cost value type")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("item_cost_value_type")]
        public Currencies ItemCostValueType { get; set; }

        [Description("Amount of time skipped for a producer")]
        [JsonProperty("time_skipped_amount")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string TimeSkippedAmount { get; set; }

        [JsonProperty("time_skipped_diamond_value")]
        [Description("Diamond value of time skipped")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int TimeSkippedDiamondValue { get; set; }

        [Description("Remaining time for producer")]
        [JsonProperty("time_remaining_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string ProducerTimeRemaining { get; set; }

        public AnalyticsEventAdPlacementShown(string adPlacement, string itemName, string auctionId, int itemDiamondValue, int itemCostValue, Currencies itemCostValueType, AnalyticsContext analyticsContext)
        {
        }
    }
}
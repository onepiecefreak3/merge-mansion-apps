using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using GameLogic.Decorations;
using GameLogic.Config.DecorationShop;
using System;

namespace Analytics
{
    [AnalyticsEvent(177, "Decoration Shop Impression", 1, null, false, true, false)]
    public class AnalyticsEventDecorationShopImpression : AnalyticEventGeneralImpression
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Decoration Id")]
        [JsonProperty("item_name")]
        public DecorationId DecorationId { get; set; }

        [Description("Decoration Shop Set Id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("decoration_set_id")]
        public DecorationShopSetId DecorationShopSetId { get; set; }

        [Description("Cost in Diamonds (if available)")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("cost_in_diamonds")]
        public long? CostInDiamonds { get; set; }

        [Description("Cost in Coins (if available)")]
        [JsonProperty("cost_in_coins")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public long? CostInCoins { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDecorationShopImpression()
        {
        }

        public AnalyticsEventDecorationShopImpression(DecorationShopInfo shop, DecorationShopSetInfo set, DecorationShopItemInfo item, Guid impressionId)
        {
        }
    }
}
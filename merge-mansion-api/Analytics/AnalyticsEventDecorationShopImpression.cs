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
        [JsonProperty("item_name")]
        [Description("Decoration Id")]
        public DecorationId DecorationId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("decoration_set_id")]
        [Description("Decoration Shop Set Id")]
        public DecorationShopSetId DecorationShopSetId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("cost_in_diamonds")]
        [Description("Cost in Diamonds (if available)")]
        public long? CostInDiamonds { get; set; }

        [JsonProperty("cost_in_coins")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Cost in Coins (if available)")]
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
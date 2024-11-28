using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace Analytics
{
    [AnalyticsEvent(150, "Flash Sale Impression", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 1, 2 })]
    public class AnalyticEventFlashSaleImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        [Description("Impression Id")]
        public string ImpressionId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("refresh_time")]
        [Description("Refresh time")]
        public MetaTime RefreshTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        [Description("Placement Id")]
        public string PlacementId { get; set; }

        [Description("Impressions")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("impressions")]
        public List<AnalyticsFlashSaleImpressionItemBase> Impressions { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventFlashSaleImpression()
        {
        }

        public AnalyticEventFlashSaleImpression(List<AnalyticsFlashSaleImpressionItemBase> impressionItems, MetaTime refreshTime, string impressionId, string placementId)
        {
        }

        public AnalyticEventFlashSaleImpression(List<AnalyticsFlashSaleImpressionItemBase> impressionItems, MetaTime refreshTime, string impressionId, string placementId, string attachment)
        {
        }

        [Description("Context where it was shown")]
        [JsonProperty("flash_sale_context")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string Context { get; set; }
    }
}
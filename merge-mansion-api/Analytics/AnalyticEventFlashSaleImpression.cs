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

        [Description("Impression Id")]
        [JsonProperty("impression_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("refresh_time")]
        [Description("Refresh time")]
        public MetaTime RefreshTime { get; set; }

        [JsonProperty("placement")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Placement Id")]
        public string PlacementId { get; set; }

        [JsonProperty("impressions")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Impressions")]
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
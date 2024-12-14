using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1, 2 })]
    [AnalyticsEvent(150, "Flash Sale Impression", 1, null, false, true, false)]
    public class AnalyticEventFlashSaleImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Impression Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        public string ImpressionId { get; set; }

        [JsonProperty("refresh_time")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Refresh time")]
        public MetaTime RefreshTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Placement Id")]
        [JsonProperty("placement")]
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

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("flash_sale_context")]
        [Description("Context where it was shown")]
        public string Context { get; set; }
    }
}
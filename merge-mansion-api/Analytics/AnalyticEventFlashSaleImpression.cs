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

        [JsonProperty("impression_id")]
        [Description("Impression Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("refresh_time")]
        [Description("Refresh time")]
        public MetaTime RefreshTime { get; set; }

        [Description("Placement Id")]
        [JsonProperty("placement")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string PlacementId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("impressions")]
        [Description("Impressions")]
        public List<AnalyticsFlashSaleImpressionItemBase> Impressions { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventFlashSaleImpression()
        {
        }

        public AnalyticEventFlashSaleImpression(List<AnalyticsFlashSaleImpressionItemBase> impressionItems, MetaTime refreshTime, string impressionId, string placementId)
        {
        }
    }
}
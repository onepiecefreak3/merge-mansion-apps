using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(157, "General Offer Impression", 1, null, false, true, false)]
    public class AnalyticEventGeneralOfferImpression : AnalyticEventGeneralImpression
    {
        public override AnalyticsEventType EventType { get; }

        [Description("EventId")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("type")]
        [Description("Impression Type")]
        public OfferImpressionType Type { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventGeneralOfferImpression()
        {
        }

        public AnalyticEventGeneralOfferImpression(string eventId, OfferImpressionType type, string iapPlatformId, string placementId, bool automaticallyShown, string impressionId)
        {
        }

        [JsonProperty("is_last_chance", NullValueHandling = (NullValueHandling)1)]
        [Description("Last chance -type of popup")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public bool IsLastChance { get; set; }

        public AnalyticEventGeneralOfferImpression(string eventId, OfferImpressionType type, string iapPlatformId, string placementId, bool automaticallyShown, string impressionId, bool isLastChance)
        {
        }
    }
}
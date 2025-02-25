using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Code.GameLogic.GameEvents;
using System;

namespace Analytics
{
    [AnalyticsEvent(158, "General Event Offer Impression", 1, null, false, true, false)]
    public class AnalyticEventGeneralEventOfferImpression : AnalyticEventGeneralImpression
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Event Offer Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_offer_id")]
        public EventOfferId EventOfferId { get; set; }

        [JsonProperty("event_offer_set_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Event Offer Set Id")]
        public EventOfferSetId EventOfferSetId { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventGeneralEventOfferImpression()
        {
        }

        public AnalyticEventGeneralEventOfferImpression(EventOfferId eventOfferId, EventOfferSetId eventOfferSetId, string placementId, bool automaticallyShown, Guid impressionId)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("trigger_type")]
        [Description("Event Offer Trigger Type")]
        public string TriggerType { get; set; }

        public AnalyticEventGeneralEventOfferImpression(EventOfferId eventOfferId, EventOfferSetId eventOfferSetId, string placementId, bool automaticallyShown, Guid impressionId, string triggerType)
        {
        }
    }
}
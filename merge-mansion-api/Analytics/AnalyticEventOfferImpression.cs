using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Offers;
using System;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 6 })]
    [AnalyticsEvent(137, "Meta Offer Impression", 1, null, false, true, false)]
    public class AnalyticEventOfferImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [Description("Offer Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        [Description("Offer Group Id")]
        [JsonProperty("group_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Platform Id")]
        [JsonProperty("iap_platform_id")]
        public string PlatformId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        [Description("Placement Id")]
        public OfferPlacementId PlacementId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Shown automatically")]
        [JsonProperty("automatic_show")]
        public bool AutomaticallyShown { get; set; }

        [Description("Offer activations")]
        [JsonProperty("activations")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int Activations { get; set; }

        [JsonProperty("impression_id")]
        [Description("Impression Id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        [JsonProperty("purchases")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Offer purchases")]
        public int Purchases { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventOfferImpression()
        {
        }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId)
        {
        }

        [Description("Offer trigger")]
        [JsonProperty("trigger_type")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public string PopupTrigger { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger)
        {
        }
    }
}
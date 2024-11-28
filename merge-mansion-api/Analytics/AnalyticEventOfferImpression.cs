using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Offers;
using System;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Player;

namespace Analytics
{
    [AnalyticsEvent(137, "Meta Offer Impression", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 6, 14, 16 })]
    public class AnalyticEventOfferImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Offer Id")]
        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        [JsonProperty("group_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Offer Group Id")]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [Description("Platform Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        public string PlatformId { get; set; }

        [JsonProperty("placement")]
        [Description("Placement Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public OfferPlacementId PlacementId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("automatic_show")]
        [Description("Shown automatically")]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("activations")]
        [Description("Offer activations")]
        public int Activations { get; set; }

        [Description("Impression Id")]
        [JsonProperty("impression_id")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }

        [Description("Offer purchases")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("purchases")]
        public int Purchases { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventOfferImpression()
        {
        }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId)
        {
        }

        [JsonProperty("trigger_type")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Offer trigger")]
        public string PopupTrigger { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger)
        {
        }

        [JsonProperty("start_date_hour")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("The offer start date and hour")]
        public MetaTime? StartDate { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("The offer end date and hour")]
        [JsonProperty("end_date_hour")]
        public MetaTime? EndDate { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("duration")]
        [Description("The offer duration in hours")]
        public long? Duration { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [Description("The offer price in USD")]
        [JsonProperty("reference_price")]
        public F64 ReferencePrice { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Array of all rewards & their amount in the offer - only contant items")]
        [JsonProperty("offer_items")]
        public string OfferItems { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Players segment for the offer")]
        [JsonProperty("segment")]
        public PlayerSegmentId Segment { get; set; }

        [Description("Offer global counter")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("offer_counter")]
        public int OfferGlobalCounter { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger, MetaTime? startDate, MetaTime? endDate, long? duration, long referencePrice, string offerItems, string segment, int offerGlobalCounter)
        {
        }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger, MetaTime? startDate, MetaTime? endDate, long? duration, F64 referencePrice, string offerItems, PlayerSegmentId segment, int offerGlobalCounter)
        {
        }
    }
}
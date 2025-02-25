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

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Offer Id")]
        public MetaOfferId OfferId { get; set; }

        [Description("Offer Group Id")]
        [JsonProperty("group_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        [Description("Platform Id")]
        public string PlatformId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        [Description("Placement Id")]
        public OfferPlacementId PlacementId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("automatic_show")]
        [Description("Shown automatically")]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("activations")]
        [Description("Offer activations")]
        public int Activations { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        [Description("Impression Id")]
        public string ImpressionId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("purchases")]
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

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("start_date_hour")]
        [Description("The offer start date and hour")]
        public MetaTime? StartDate { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("end_date_hour")]
        [Description("The offer end date and hour")]
        public MetaTime? EndDate { get; set; }

        [Description("The offer duration in hours")]
        [JsonProperty("duration")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public long? Duration { get; set; }

        [Description("The offer price in USD")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("reference_price")]
        public F64 ReferencePrice { get; set; }

        [Description("Array of all rewards & their amount in the offer - only contant items")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("offer_items")]
        public string OfferItems { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("segment")]
        [Description("Players segment for the offer")]
        public PlayerSegmentId Segment { get; set; }

        [JsonProperty("offer_counter")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Offer global counter")]
        public int OfferGlobalCounter { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger, MetaTime? startDate, MetaTime? endDate, long? duration, long referencePrice, string offerItems, string segment, int offerGlobalCounter)
        {
        }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger, MetaTime? startDate, MetaTime? endDate, long? duration, F64 referencePrice, string offerItems, PlayerSegmentId segment, int offerGlobalCounter)
        {
        }

        [Description("Tiered offer step for the offer")]
        [MetaMember(20, (MetaMemberFlags)0)]
        [JsonProperty("step", NullValueHandling = (NullValueHandling)1)]
        public int? Step { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger, MetaTime? startDate, MetaTime? endDate, long? duration, F64 referencePrice, string offerItems, PlayerSegmentId segment, int offerGlobalCounter, int? step)
        {
        }
    }
}
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
    [MetaBlockedMembers(new int[] { 6, 14, 16 })]
    [AnalyticsEvent(137, "Meta Offer Impression", 1, null, false, true, false)]
    public class AnalyticEventOfferImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Offer Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public MetaOfferId OfferId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("group_id")]
        [Description("Offer Group Id")]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [JsonProperty("iap_platform_id")]
        [Description("Platform Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string PlatformId { get; set; }

        [Description("Placement Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        public OfferPlacementId PlacementId { get; set; }

        [Description("Shown automatically")]
        [JsonProperty("automatic_show")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Offer activations")]
        [JsonProperty("activations")]
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

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("trigger_type")]
        [Description("Offer trigger")]
        public string PopupTrigger { get; set; }

        public AnalyticEventOfferImpression(MetaOfferId offerId, MetaOfferGroupId offerGroupId, string platformId, OfferPlacementId placementId, bool automaticallyShown, int activations, int purchases, string impressionId, string popupTrigger)
        {
        }

        [Description("The offer start date and hour")]
        [JsonProperty("start_date_hour")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public MetaTime? StartDate { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("end_date_hour")]
        [Description("The offer end date and hour")]
        public MetaTime? EndDate { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("duration")]
        [Description("The offer duration in hours")]
        public long? Duration { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("reference_price")]
        [Description("The offer price in USD")]
        public F64 ReferencePrice { get; set; }

        [JsonProperty("offer_items")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Array of all rewards & their amount in the offer - only contant items")]
        public string OfferItems { get; set; }

        [Description("Players segment for the offer")]
        [MetaMember(19, (MetaMemberFlags)0)]
        [JsonProperty("segment")]
        public PlayerSegmentId Segment { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [Description("Offer global counter")]
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
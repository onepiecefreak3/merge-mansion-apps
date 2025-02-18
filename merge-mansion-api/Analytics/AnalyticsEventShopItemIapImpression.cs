using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Offers;

namespace Analytics
{
    [AnalyticsEvent(192, "Shop Item IAP Impression", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 6 })]
    public class AnalyticsEventShopItemIapImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Item Id")]
        [JsonProperty("item_name")]
        public InAppProductId ShopItemIapId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        [Description("Platform Id")]
        public string PlatformId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        [Description("Placement Id")]
        public OfferPlacementId PlacementId { get; set; }

        [JsonProperty("automatic_show")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Shown automatically")]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        [Description("Impression Id")]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventShopItemIapImpression()
        {
        }

        public AnalyticsEventShopItemIapImpression(InAppProductId shopItemIapId, string platformId, OfferPlacementId placementId, bool automaticallyShown, string impressionId)
        {
        }
    }
}
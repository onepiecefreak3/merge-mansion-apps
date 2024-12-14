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
        [JsonProperty("item_name")]
        [Description("Item Id")]
        public InAppProductId ShopItemIapId { get; set; }

        [JsonProperty("iap_platform_id")]
        [Description("Platform Id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string PlatformId { get; set; }

        [Description("Placement Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("placement")]
        public OfferPlacementId PlacementId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("automatic_show")]
        [Description("Shown automatically")]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Impression Id")]
        [JsonProperty("impression_id")]
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
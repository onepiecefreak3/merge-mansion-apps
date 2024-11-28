using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Offers;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 6 })]
    [AnalyticsEvent(192, "Shop Item IAP Impression", 1, null, false, true, false)]
    public class AnalyticsEventShopItemIapImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Item Id")]
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
        [Description("Shown automatically")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool AutomaticallyShown { get; set; }

        [Description("Impression Id")]
        [MetaMember(5, (MetaMemberFlags)0)]
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
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(189, "Rewarded ad impression", 1, null, true, true, false)]
    public class AnalyticsEventAdImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("ad_platform")]
        [Description("Ad platform")]
        public string AdPlatform { get; set; }

        [Description("Ad Network (previously Ad Source)")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        public string AdSource { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Ad unit name")]
        [JsonProperty("ad_unit_name")]
        public string AdUnitName { get; set; }

        [Description("Ad format")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("ad_format")]
        public string AdFormat { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Currency")]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [Description("Value")]
        [JsonProperty("value")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public double? Value { get; set; }

        [Description("Auction Id")]
        [JsonProperty("auction_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }

        [JsonProperty("ad_placement")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Item name")]
        public string ItemName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventAdImpression()
        {
        }

        public AnalyticsEventAdImpression(string adPlatform, string adSource, string adUnitName, string adFormat, string currency, double? value, string auctionId, string adPlacement, string itemName)
        {
        }
    }
}
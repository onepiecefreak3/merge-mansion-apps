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

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("ad_network")]
        [Description("Ad Network (previously Ad Source)")]
        public string AdSource { get; set; }

        [JsonProperty("ad_unit_name")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Ad unit name")]
        public string AdUnitName { get; set; }

        [JsonProperty("ad_format")]
        [Description("Ad format")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AdFormat { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("currency")]
        [Description("Currency")]
        public string Currency { get; set; }

        [Description("Value")]
        [JsonProperty("value")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public double? Value { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("auction_id")]
        [Description("Auction Id")]
        public string AuctionId { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("ad_placement")]
        [Description("Ad placement")]
        public string AdPlacement { get; set; }

        [JsonProperty("item_name")]
        [Description("Item name")]
        [MetaMember(9, (MetaMemberFlags)0)]
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
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaReservedMembers(200, 299)]
    public abstract class AnalyticEventGeneralImpression : AnalyticsServersideEventBase
    {
        [MetaMember(200, (MetaMemberFlags)0)]
        [JsonProperty("iap_platform_id")]
        [Description("Platform Id")]
        public string PlatformId { get; set; }

        [Description("Placement Id")]
        [JsonProperty("placement")]
        [MetaMember(201, (MetaMemberFlags)0)]
        public string PlacementId { get; set; }

        [JsonProperty("automatic_show")]
        [Description("Shown automatically")]
        [MetaMember(202, (MetaMemberFlags)0)]
        public bool AutomaticallyShown { get; set; }

        [MetaMember(203, (MetaMemberFlags)0)]
        [JsonProperty("impression_id")]
        [Description("Random impression id")]
        public string ImpressionId { get; set; }

        public AnalyticEventGeneralImpression()
        {
        }

        protected AnalyticEventGeneralImpression(string platformId, string placementId, bool automaticallyShown, string impressionId)
        {
        }
    }
}
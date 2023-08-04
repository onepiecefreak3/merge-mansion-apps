using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Analytics;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializable]
    public struct PlayerAnalyticsEventDPL2
    {
        [JsonProperty("analytics_event_name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string AnalyticsEventName;
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("timestamp")]
        public MetaTime ModelTime;
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("unique_id")]
        public MetaUInt128 UniqueId;
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        public AnalyticsContextBase Context;
        [JsonProperty("payload")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public AnalyticsEventBase Payload;
    }
}
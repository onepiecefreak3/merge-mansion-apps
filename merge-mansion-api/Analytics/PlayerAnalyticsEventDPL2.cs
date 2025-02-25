using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Analytics;

namespace Analytics
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 1 })]
    public struct PlayerAnalyticsEventDPL2
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("analytics_event_name")]
        public string AnalyticsEventName;
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("timestamp")]
        public MetaTime ModelTime;
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("unique_id")]
        public MetaUInt128 UniqueId;
        [JsonProperty("context")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public AnalyticsContextBase Context;
        [MetaOnMemberDeserializationFailure("CreateAnalyticsEventDeserializationSubstitute")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("payload")]
        public AnalyticsEventBase Payload;
    }
}
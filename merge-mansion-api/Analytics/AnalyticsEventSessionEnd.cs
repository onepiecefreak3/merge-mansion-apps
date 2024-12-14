using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Metaplay.Core;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 2 })]
    [AnalyticsEvent(121, "Session end", 1, null, false, true, false)]
    public class AnalyticsEventSessionEnd : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Session length in seconds")]
        [JsonProperty("session_length")]
        public double SessionLengthInSeconds { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSessionEnd()
        {
        }

        public AnalyticsEventSessionEnd(MetaDuration sessionLength)
        {
        }
    }
}
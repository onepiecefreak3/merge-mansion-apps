using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(132, "Player accepted TOS", 1, null, false, true, false)]
    public class AnalyticsPlayerAcceptedToS : AnalyticsServersideEventBase
    {
        [JsonProperty("version")]
        [Description("Version of the ToS accepted")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public TOSAcceptance Acceptance;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsPlayerAcceptedToS(TOSAcceptance acceptanceVersion)
        {
        }

        public AnalyticsPlayerAcceptedToS()
        {
        }

        public AnalyticsPlayerAcceptedToS(int acceptanceVersion)
        {
        }
    }
}
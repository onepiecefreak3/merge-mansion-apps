using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [AnalyticsEvent(140, "12traits survey completed", 1, null, true, true, false)]
    public class AnalyticsEventTraits12SurveyCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Broadcast Id of the completed survey")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("broadcast_id")]
        public int BroadcastId { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventTraits12SurveyCompleted()
        {
        }

        public AnalyticsEventTraits12SurveyCompleted(int broadcastId)
        {
        }
    }
}
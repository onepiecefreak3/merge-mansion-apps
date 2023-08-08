using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(141, "12traits survey started", 1, null, false, true, false)]
    public class AnalyticsEventTraits12SurveyStarted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("broadcast_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Broadcast Id of the started survey")]
        public int BroadcastId { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventTraits12SurveyStarted()
        {
        }

        public AnalyticsEventTraits12SurveyStarted(int broadcastId)
        {
        }
    }
}
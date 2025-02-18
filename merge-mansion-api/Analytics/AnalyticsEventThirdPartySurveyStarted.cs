using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(141, "Third Party Survey started", 1, null, false, true, false)]
    public class AnalyticsEventThirdPartySurveyStarted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Broadcast Id of the started survey")]
        [JsonProperty("broadcast_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int BroadcastId { get; set; }

        [Description("Survey Type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("survey_type")]
        public string SurveyType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventThirdPartySurveyStarted()
        {
        }

        public AnalyticsEventThirdPartySurveyStarted(int broadcastId, string surveyType)
        {
        }
    }
}
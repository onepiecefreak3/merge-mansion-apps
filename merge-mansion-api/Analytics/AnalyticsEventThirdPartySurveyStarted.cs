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
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("broadcast_id")]
        public int BroadcastId { get; set; }

        [JsonProperty("survey_type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Survey Type")]
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
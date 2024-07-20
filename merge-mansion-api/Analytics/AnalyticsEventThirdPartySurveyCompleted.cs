using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [JsonConverter(typeof(AnalyticsEventThirdPartySurveyCompletedJsonConverter))]
    [AnalyticsEvent(140, "Third Party Survey completed", 1, null, true, true, false)]
    public class AnalyticsEventThirdPartySurveyCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Broadcast Id of the completed survey")]
        [JsonProperty("broadcast_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int BroadcastId { get; set; }

        [JsonProperty("survey_type")]
        [Description("Survey Type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string SurveyType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventThirdPartySurveyCompleted()
        {
        }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType)
        {
        }

        [Description("Association Id")]
        [JsonProperty("association_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string AssociationId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("survey_response")]
        [Description("Survey Response")]
        public string SurveyResponse { get; set; }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType, string associationId, string surveyResponse)
        {
        }
    }
}
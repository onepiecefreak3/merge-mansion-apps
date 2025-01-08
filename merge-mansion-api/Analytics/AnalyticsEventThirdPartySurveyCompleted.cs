using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [AnalyticsEvent(140, "Third Party Survey completed", 1, null, true, true, false)]
    [JsonConverter(typeof(AnalyticsEventThirdPartySurveyCompletedJsonConverter))]
    public class AnalyticsEventThirdPartySurveyCompleted : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("broadcast_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Broadcast Id of the completed survey")]
        public int BroadcastId { get; set; }

        [JsonProperty("survey_type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Survey Type")]
        public string SurveyType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventThirdPartySurveyCompleted()
        {
        }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType)
        {
        }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Association Id")]
        [JsonProperty("association_id")]
        public string AssociationId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Survey Response")]
        [JsonProperty("survey_response")]
        public string SurveyResponse { get; set; }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType, string associationId, string surveyResponse)
        {
        }
    }
}
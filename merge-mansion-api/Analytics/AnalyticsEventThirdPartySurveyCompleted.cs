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

        [Description("Broadcast Id of the completed survey")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("broadcast_id")]
        public int BroadcastId { get; set; }

        [Description("Survey Type")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("survey_type")]
        public string SurveyType { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventThirdPartySurveyCompleted()
        {
        }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType)
        {
        }

        [Description("Association Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("association_id")]
        public string AssociationId { get; set; }

        [Description("Survey Response")]
        [JsonProperty("survey_response")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string SurveyResponse { get; set; }

        public AnalyticsEventThirdPartySurveyCompleted(int broadcastId, string surveyType, string associationId, string surveyResponse)
        {
        }
    }
}
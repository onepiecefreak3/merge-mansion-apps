using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using Game.Logic;
using Metaplay.Core.Rewards;

namespace Analytics
{
    [AnalyticsEvent(123, "Survey results received", 1, null, false, true, false)]
    public class AnalyticsEventSurveyResultsReceived : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("survey_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the received survey")]
        public int SurveyId { get; set; }

        [Description("Survey answers")]
        [JsonProperty("answers")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<SurveyAnswerItem> Answers { get; set; }

        [Description("Rewards received for the survey")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("rewards")]
        public List<MetaPlayerRewardBase> Rewards { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSurveyResultsReceived()
        {
        }

        public AnalyticsEventSurveyResultsReceived(int surveyId, List<SurveyAnswerItem> answers, List<MetaPlayerRewardBase> rewards)
        {
        }
    }
}
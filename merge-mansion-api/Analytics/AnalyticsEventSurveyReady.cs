using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 4 })]
    [AnalyticsEvent(124, "Survey sent to player", 1, null, false, true, false)]
    public class AnalyticsEventSurveyReady : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("survey_id")]
        [Description("ID of the received survey")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SurveyId { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [JsonProperty("questions")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Questions delivered in the survey")]
        public Dictionary<int, string> Questions { get; set; }

        [JsonProperty("rewards")]
        [Description("Rewards received for the survey")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventSurveyReady()
        {
        }

        public AnalyticsEventSurveyReady(int surveyId, Dictionary<int, string> questions, List<PlayerReward> rewards)
        {
        }
    }
}
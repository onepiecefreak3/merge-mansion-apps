using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using Metaplay.Core;
using System;

namespace Analytics
{
    [AnalyticsEvent(203, "Boulton League event score changed", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class AnalyticsEventBoultonLeagueEventScoreChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        [Description("Event id")]
        public BoultonLeagueEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("division_id")]
        [Description("Leaderboard division id")]
        public EntityId DivisionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("stage_number")]
        [Description("League stage number")]
        public int StageNumber { get; set; }

        [JsonProperty("score_amount")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Amount of points/score gained")]
        public int ScoreAmount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("score_source_type")]
        [Description("Source of points/score gained")]
        public BoultonLeagueEventScoreSourceType ScoreSourceType { get; set; }

        [JsonProperty("total_score")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("New total score")]
        public int TotalScore { get; set; }

        [Description("Possible score requirement to avoid demotion to the previous league stage after the event concludes")]
        [JsonProperty("stage_demotion_score_threshold")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int StageDemotionScoreThreshold { get; set; }

        [Description("Possible score requirement for promotion to the next league stage after the event concludes")]
        [JsonProperty("stage_promotion_score_threshold")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int StagePromotionScoreThreshold { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventBoultonLeagueEventScoreChanged()
        {
        }

        public AnalyticsEventBoultonLeagueEventScoreChanged(BoultonLeagueEventModel eventModel, int scoreAmount, BoultonLeagueEventScoreSourceType scoreSourceType)
        {
        }

        [Description("Leaderboard division rank")]
        [JsonProperty("division_rank")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int DivisionRank { get; set; }
    }
}
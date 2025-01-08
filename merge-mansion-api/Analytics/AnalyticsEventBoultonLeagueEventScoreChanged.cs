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
    public class AnalyticsEventBoultonLeagueEventScoreChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Event id")]
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public BoultonLeagueEventId EventId { get; set; }

        [JsonProperty("division_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Leaderboard division id")]
        public EntityId DivisionId { get; set; }

        [JsonProperty("stage_number")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("League stage number")]
        public int StageNumber { get; set; }

        [Description("Amount of points/score gained")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("score_amount")]
        public int ScoreAmount { get; set; }

        [Description("Source of points/score gained")]
        [JsonProperty("score_source_type")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public BoultonLeagueEventScoreSourceType ScoreSourceType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("total_score")]
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

        [JsonProperty("division_rank")]
        [Description("Leaderboard division rank")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int DivisionRank { get; set; }
    }
}
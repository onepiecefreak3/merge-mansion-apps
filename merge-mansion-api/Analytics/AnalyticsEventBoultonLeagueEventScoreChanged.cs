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

        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Event id")]
        public BoultonLeagueEventId EventId { get; set; }

        [Description("Leaderboard division id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("division_id")]
        public EntityId DivisionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("League stage number")]
        [JsonProperty("stage_number")]
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

        [JsonProperty("stage_demotion_score_threshold")]
        [Description("Possible score requirement to avoid demotion to the previous league stage after the event concludes")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int StageDemotionScoreThreshold { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Possible score requirement for promotion to the next league stage after the event concludes")]
        [JsonProperty("stage_promotion_score_threshold")]
        public int StagePromotionScoreThreshold { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventBoultonLeagueEventScoreChanged()
        {
        }

        public AnalyticsEventBoultonLeagueEventScoreChanged(BoultonLeagueEventModel eventModel, int scoreAmount, BoultonLeagueEventScoreSourceType scoreSourceType)
        {
        }

        [Description("Leaderboard division rank")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("division_rank")]
        public int DivisionRank { get; set; }
    }
}
using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Code.GameLogic.GameEvents;
using System;
using Metaplay.Core;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1 })]
    [AnalyticsEvent(164, "Leaderboard event score changed", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class AnalyticsEventLeaderboardEventScoreChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Leaderboard event where score changed")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public LeaderboardEventId EventId { get; set; }

        [Description("Action that caused score change")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("source_action")]
        public LeaderboardEventScoreChangeSourceAction SourceAction { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("How much score changed")]
        [JsonProperty("score_change")]
        public int ScoreChange { get; set; }

        [Description("Total score after change")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("total_score")]
        public int TotalScore { get; set; }

        [JsonProperty("leaderboard_id")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Leaderboard division id")]
        public EntityId DivisionId { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventLeaderboardEventScoreChanged()
        {
        }

        public AnalyticsEventLeaderboardEventScoreChanged(LeaderboardEventId eventId, LeaderboardEventScoreChangeSourceAction sourceAction, int scoreChange, int totalScore, EntityId divisionId)
        {
        }
    }
}
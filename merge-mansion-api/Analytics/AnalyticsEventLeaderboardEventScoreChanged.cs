using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Code.GameLogic.GameEvents;
using System;
using Metaplay.Core;

namespace Analytics
{
    [AnalyticsEvent(164, "Leaderboard event score changed", 1, null, true, true, false)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class AnalyticsEventLeaderboardEventScoreChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Leaderboard event where score changed")]
        [JsonProperty("event_id")]
        public LeaderboardEventId EventId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Action that caused score change")]
        [JsonProperty("source_action")]
        public LeaderboardEventScoreChangeSourceAction SourceAction { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("score_change")]
        [Description("How much score changed")]
        public int ScoreChange { get; set; }

        [JsonProperty("total_score")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Total score after change")]
        public int TotalScore { get; set; }

        [JsonProperty("leaderboard_id")]
        [Description("Leaderboard division id")]
        [MetaMember(6, (MetaMemberFlags)0)]
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
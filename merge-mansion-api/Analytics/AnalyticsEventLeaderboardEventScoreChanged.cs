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
    public class AnalyticsEventLeaderboardEventScoreChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Leaderboard event where score changed")]
        public LeaderboardEventId EventId { get; set; }

        [Description("Action that caused score change")]
        [JsonProperty("source_action")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public LeaderboardEventScoreChangeSourceAction SourceAction { get; set; }

        [Description("How much score changed")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("score_change")]
        public int ScoreChange { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("total_score")]
        [Description("Total score after change")]
        public int TotalScore { get; set; }

        [Description("Leaderboard division id")]
        [JsonProperty("leaderboard_id")]
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
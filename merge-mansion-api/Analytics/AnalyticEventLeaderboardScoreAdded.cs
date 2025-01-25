using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using Metaplay.Core;
using System;

namespace Analytics
{
    [AnalyticsEvent(204, "Leaderboard points added", 1, null, false, true, false)]
    public class AnalyticEventLeaderboardScoreAdded : AnalyticsServersideDivisionEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("leaderboard_id")]
        [Description("Leaderboard division id")]
        public EntityId DivisionId { get; set; }

        [JsonProperty("event_id")]
        [Description("Leaderboard event id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [Description("Player Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("placement_before")]
        [Description("Placement before")]
        public int PlacementBefore { get; set; }

        [JsonProperty("placement_after")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Placement after")]
        public int PlacementAfter { get; set; }

        [JsonProperty("score")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Score")]
        public int Score { get; set; }

        [JsonProperty("total_score")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Score")]
        public int TotalScore { get; set; }

        [Description("Source of score")]
        [JsonProperty("source_action")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string SourceAction { get; set; }
        public override string EventDescription { get; }

        private AnalyticEventLeaderboardScoreAdded()
        {
        }

        public AnalyticEventLeaderboardScoreAdded(EntityId divisionId, string eventId, string playerId, int placementBefore, int placementAfter, int score, int totalScore, string sourceAction)
        {
        }

        [Description("Leaderboard division rank")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("division_rank")]
        public int DivisionRank { get; set; }

        [Description("Bot type")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("bot_type")]
        public string BotType { get; set; }

        public AnalyticEventLeaderboardScoreAdded(EntityId divisionId, string eventId, string playerId, int placementBefore, int placementAfter, int score, int totalScore, string sourceAction, string botType)
        {
        }
    }
}
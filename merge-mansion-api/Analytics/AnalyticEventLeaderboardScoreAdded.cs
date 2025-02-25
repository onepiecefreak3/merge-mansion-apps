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

        [JsonProperty("leaderboard_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Leaderboard division id")]
        public EntityId DivisionId { get; set; }

        [JsonProperty("event_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Leaderboard event id")]
        public string EventId { get; set; }

        [JsonProperty("player_id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Player Id")]
        public string PlayerId { get; set; }

        [JsonProperty("placement_before")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Placement before")]
        public int PlacementBefore { get; set; }

        [Description("Placement after")]
        [JsonProperty("placement_after")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int PlacementAfter { get; set; }

        [Description("Score")]
        [JsonProperty("score")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [JsonProperty("total_score")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Score")]
        public int TotalScore { get; set; }

        [JsonProperty("source_action")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Source of score")]
        public string SourceAction { get; set; }
        public override string EventDescription { get; }

        private AnalyticEventLeaderboardScoreAdded()
        {
        }

        public AnalyticEventLeaderboardScoreAdded(EntityId divisionId, string eventId, string playerId, int placementBefore, int placementAfter, int score, int totalScore, string sourceAction)
        {
        }

        [JsonProperty("division_rank")]
        [Description("Leaderboard division rank")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int DivisionRank { get; set; }

        [JsonProperty("bot_type")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Bot type")]
        public string BotType { get; set; }

        public AnalyticEventLeaderboardScoreAdded(EntityId divisionId, string eventId, string playerId, int placementBefore, int placementAfter, int score, int totalScore, string sourceAction, string botType)
        {
        }
    }
}
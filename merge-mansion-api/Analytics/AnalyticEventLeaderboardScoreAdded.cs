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

        [Description("Leaderboard division id")]
        [JsonProperty("leaderboard_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityId DivisionId { get; set; }

        [Description("Leaderboard event id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [Description("Player Id")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }

        [JsonProperty("placement_before")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Placement before")]
        public int PlacementBefore { get; set; }

        [Description("Placement after")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("placement_after")]
        public int PlacementAfter { get; set; }

        [JsonProperty("score")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Score")]
        public int Score { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("total_score")]
        [Description("Score")]
        public int TotalScore { get; set; }

        [Description("Source of score")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("source_action")]
        public string SourceAction { get; set; }
        public override string EventDescription { get; }

        private AnalyticEventLeaderboardScoreAdded()
        {
        }

        public AnalyticEventLeaderboardScoreAdded(EntityId divisionId, string eventId, string playerId, int placementBefore, int placementAfter, int score, int totalScore, string sourceAction)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using Metaplay.Core;
using System.Collections.Generic;
using System;
using Code.GameLogic.GameEvents;

namespace Analytics
{
    [AnalyticsEvent(165, "Leaderboard snapshot", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 6 })]
    public class AnalyticEventLeaderboardSnapshot : AnalyticsServersideDivisionEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [Description("Leaderboard division id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("leaderboard_id")]
        public EntityId DivisionId { get; set; }

        [Description("Participants")]
        [JsonProperty("players")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<LeaderboardSnapshotPlayerEntry> Players { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("gathered_from")]
        [Description("Snapshot taken at")]
        public AnalyticsLeaderboardSnapshotType SnapshotType { get; set; }

        [Description("New player id if added")]
        [JsonProperty("new_player_id", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string NewPlayerId { get; set; }
        public override string EventDescription { get; }

        private AnalyticEventLeaderboardSnapshot()
        {
        }

        public AnalyticEventLeaderboardSnapshot(EntityId divisionId, List<LeaderboardSnapshotPlayerEntry> players, AnalyticsLeaderboardSnapshotType snapshotType, string newPlayerId)
        {
        }

        [Description("Division rank")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int Rank { get; set; }

        [JsonProperty("event_id")]
        [Description("Event Id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        public AnalyticEventLeaderboardSnapshot(EntityId divisionId, List<LeaderboardSnapshotPlayerEntry> players, AnalyticsLeaderboardSnapshotType snapshotType, int rank, LeaderboardEventId eventId, string newPlayerId)
        {
        }

        public AnalyticEventLeaderboardSnapshot(EntityId divisionId, List<LeaderboardSnapshotPlayerEntry> players, AnalyticsLeaderboardSnapshotType snapshotType, int rank, string eventId, string newPlayerId)
        {
        }
    }
}
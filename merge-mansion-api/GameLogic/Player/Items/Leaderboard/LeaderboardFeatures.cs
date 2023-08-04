using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Items.Leaderboard
{
    [MetaSerializable]
    public class LeaderboardFeatures
    {
        public static LeaderboardFeatures NoLeaderboardFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool HasLeaderboardFeatures { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ScoreContribution { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public LeaderboardEventId EventId { get; set; }

        private LeaderboardFeatures()
        {
        }

        public LeaderboardFeatures(bool hasLeaderboardFeatures, int scoreContribution, LeaderboardEventId eventId)
        {
        }
    }
}
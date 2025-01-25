using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializable]
    public class ShortLeaderboardEventDivisionParticipantSnapshot
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ParticipantIndex { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        private ShortLeaderboardEventDivisionParticipantSnapshot()
        {
        }

        public ShortLeaderboardEventDivisionParticipantSnapshot(int participantIndex, int score, string displayName)
        {
        }
    }
}
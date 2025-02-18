using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializableDerived(3)]
    public class ShortLeaderboardDivisionHistoryEntry : PlayerDivisionHistoryEntryBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerDivisionScore PlayerScore { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int LeaderboardPlacementIndex { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<ShortLeaderboardEventDivisionParticipantSnapshot> ParticipantSnapshots { get; set; }

        public ShortLeaderboardDivisionHistoryEntry(EntityId divisionId, DivisionIndex divisionIndex, IDivisionRewards rewards, PlayerDivisionScore playerScore, int leaderboardPlacementIndex, List<ShortLeaderboardEventDivisionParticipantSnapshot> participantSnapshots) : base(divisionId, divisionIndex, rewards)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Leaderboard
{
    [MetaSerializableDerived(1)]
    public class PlayerDivisionHistoryEntry : PlayerDivisionHistoryEntryBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerDivisionScore PlayerScore { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int LeaderboardPlacementIndex { get; set; }

        public PlayerDivisionHistoryEntry(EntityId divisionId, DivisionIndex divisionIndex, IDivisionRewards rewards, PlayerDivisionScore playerScore, int leaderboardPlacementIndex) : base(divisionId, divisionIndex, rewards)
        {
        }

        private PlayerDivisionHistoryEntry() : base(EntityId.None, new DivisionIndex(), null)
        {
        }
    }
}
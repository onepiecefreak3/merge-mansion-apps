using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [MetaSerializableDerived(2)]
    public class BoultonLeagueDivisionHistoryEntry : PlayerDivisionHistoryEntryBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerDivisionScore PlayerScore { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int LeaderboardPlacementIndex { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<BoultonLeagueDivisionParticipantSnapshot> LeaderboardEntries { get; set; }

        public BoultonLeagueDivisionHistoryEntry(EntityId divisionId, DivisionIndex divisionIndex, IDivisionRewards rewards, PlayerDivisionScore playerScore, int leaderboardPlacementIndex, List<BoultonLeagueDivisionParticipantSnapshot> leaderboardEntries, int stageNumber)
            : base(divisionId, divisionIndex, rewards)
        {
        }

        private BoultonLeagueDivisionHistoryEntry() : base(default, default, null)
        {
        }
    }
}
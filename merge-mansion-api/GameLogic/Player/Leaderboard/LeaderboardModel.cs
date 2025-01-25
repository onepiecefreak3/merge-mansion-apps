using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Leaderboard
{
    [SupportedSchemaVersions(1, 3)]
    [MetaSerializableDerived(3)]
    public class LeaderboardModel : PlayerDivisionModelBase<LeaderboardModel, PlayerDivisionParticipantState, PlayerDivisionScore, PlayerDivisionAvatar>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public LeaderboardEventId EventId { get; set; }
        public override int TicksPerSecond { get; }

        public LeaderboardModel()
        {
        }
    }
}
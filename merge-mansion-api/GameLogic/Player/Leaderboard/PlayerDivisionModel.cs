using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Leaderboard
{
    [SupportedSchemaVersions(1, 3)]
    [MetaSerializableDerived(3)]
    public class PlayerDivisionModel : PlayerDivisionModelBase<PlayerDivisionModel, PlayerDivisionParticipantState, PlayerDivisionScore, PlayerDivisionAvatar>
    {
        public override int TicksPerSecond { get; }

        public PlayerDivisionModel()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public LeaderboardEventId EventId { get; set; }
    }
}
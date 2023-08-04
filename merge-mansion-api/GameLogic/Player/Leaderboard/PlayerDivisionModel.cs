using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using System;

namespace GameLogic.Player.Leaderboard
{
    [SupportedSchemaVersions(1, 2)]
    [MetaSerializableDerived(3)]
    public class PlayerDivisionModel : PlayerDivisionModelBase<PlayerDivisionModel, PlayerDivisionParticipantState, PlayerDivisionScore, PlayerDivisionAvatar>
    {
        public override int TicksPerSecond { get; }

        public PlayerDivisionModel()
        {
        }
    }
}
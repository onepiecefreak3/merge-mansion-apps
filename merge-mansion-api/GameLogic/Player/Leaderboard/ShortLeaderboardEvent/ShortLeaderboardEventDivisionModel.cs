using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using Metaplay.Core.League;
using Metaplay.Core.MultiplayerEntity;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializableDerived(5)]
    [SupportedSchemaVersions(1, 1)]
    public class ShortLeaderboardEventDivisionModel : PlayerDivisionModelBase<ShortLeaderboardEventDivisionModel, ShortLeaderboardEventDivisionParticipantState, PlayerDivisionScore, ShortLeaderboardEventDivisionAvatar>, IMetacorePlayerDivisionModel<ShortLeaderboardEventDivisionModel, ShortLeaderboardEventDivisionParticipantState>, IPlayerDivisionModel<ShortLeaderboardEventDivisionModel>, IPlayerDivisionModel, IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IDivisionModel<ShortLeaderboardEventDivisionModel>, IMultiplayerModel<ShortLeaderboardEventDivisionModel>, IModel<ShortLeaderboardEventDivisionModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime? MatchMakingEnded { get; set; }
        public override int TicksPerSecond { get; }
        public bool HasMatchMakingEnded { get; }

        public ShortLeaderboardEventDivisionModel()
        {
        }
    }
}
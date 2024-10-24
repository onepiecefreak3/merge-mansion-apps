using Metaplay.Core.League.Player;
using Metaplay.Core.League;
using Metaplay.Core.MultiplayerEntity;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Leaderboard
{
    public interface IMetacorePlayerDivisionModel<TDivisionModel, TParticipantState> : IPlayerDivisionModel<TDivisionModel>, IPlayerDivisionModel, IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IDivisionModel<TDivisionModel>, IMultiplayerModel<TDivisionModel>, IModel<TDivisionModel>
    {
        Dictionary<int, TParticipantState> Participants { get; set; }

        string EventId { get; }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using Metaplay.Core.League;
using Metaplay.Core.MultiplayerEntity;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [SupportedSchemaVersions(1, 1)]
    [MetaSerializableDerived(4)]
    public class BoultonLeagueDivisionModel : PlayerDivisionModelBase<BoultonLeagueDivisionModel, BoultonLeagueDivisionParticipantState, PlayerDivisionScore, BoultonLeagueDivisionAvatar>, IMetacorePlayerDivisionModel<BoultonLeagueDivisionModel, BoultonLeagueDivisionParticipantState>, IPlayerDivisionModel<BoultonLeagueDivisionModel>, IPlayerDivisionModel, IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IDivisionModel<BoultonLeagueDivisionModel>, IMultiplayerModel<BoultonLeagueDivisionModel>, IModel<BoultonLeagueDivisionModel>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }
        public override int TicksPerSecond { get; }

        public BoultonLeagueDivisionModel()
        {
        }
    }
}
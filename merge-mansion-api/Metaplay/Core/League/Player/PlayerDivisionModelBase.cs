using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity;
using System.Runtime.Serialization;

namespace Metaplay.Core.League.Player
{
    [MetaReservedMembers(400, 500)]
    public abstract class PlayerDivisionModelBase<TModel, TParticipantState, TDivisionScore, TDivisionPlayerAvatar> : DivisionModelBase<TModel, TParticipantState, TDivisionScore>, IPlayerDivisionModel<TModel>, IPlayerDivisionModel, IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IDivisionModel<TModel>, IMultiplayerModel<TModel>, IModel<TModel>
    {
        [IgnoreDataMember]
        private IPlayerDivisionModelServerListenerCore _BackingField_ServerListenerCore;
        [IgnoreDataMember]
        private IPlayerDivisionModelClientListenerCore _BackingField_ClientListenerCore;
        public IPlayerDivisionModelServerListenerCore ServerListenerCore { get; }
        public IPlayerDivisionModelClientListenerCore ClientListenerCore { get; }

        IPlayerDivisionModelServerListenerCore Metaplay.Core.League.Player.IPlayerDivisionModel.ServerListenerCore { get; }

        IPlayerDivisionModelClientListenerCore Metaplay.Core.League.Player.IPlayerDivisionModel.ClientListenerCore { get; }

        protected PlayerDivisionModelBase()
        {
        }
    }
}
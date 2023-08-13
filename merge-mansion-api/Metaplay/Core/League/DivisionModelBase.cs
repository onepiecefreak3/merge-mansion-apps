using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity;
using System.Runtime.Serialization;
using Metaplay.Core.Analytics;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.League
{
    [MetaReservedMembers(300, 400)]
    [LeaguesEnabledCondition]
    public abstract class DivisionModelBase<TModel, TParticipantState, TDivisionScore> : MultiplayerModelBase<TModel>, IDivisionModel<TModel>, IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IMultiplayerModel<TModel>, IModel<TModel>
    {
        [IgnoreDataMember]
        public IDivisionModelServerListenerCore ServerListenerCore { get; }

        [IgnoreDataMember]
        public IDivisionModelClientListenerCore ClientListenerCore { get; }

        IDivisionModelServerListenerCore Metaplay.Core.League.IDivisionModel.ServerListenerCore { get; }

        IDivisionModelClientListenerCore Metaplay.Core.League.IDivisionModel.ClientListenerCore { get; }

        [IgnoreDataMember]
        public AnalyticsEventHandler<IDivisionModel, DivisionEventBase> AnalyticsEventHandler { get; set; }

        [MetaMember(303, (MetaMemberFlags)0)]
        public DivisionIndex DivisionIndex { get; set; }

        [MetaMember(304, (MetaMemberFlags)0)]
        public Dictionary<EntityId, TParticipantState> Participants { get; set; }

        [MetaMember(305, (MetaMemberFlags)0)]
        public MetaTime StartsAt { get; set; }

        [MetaMember(306, (MetaMemberFlags)0)]
        public MetaTime EndsAt { get; set; }

        [MetaMember(308, (MetaMemberFlags)0)]
        public MetaTime EndingSoonStartsAt { get; set; }

        [MetaMember(307, (MetaMemberFlags)0)]
        public bool IsConcluded { get; set; }

        protected DivisionModelBase()
        {
        }
    }
}
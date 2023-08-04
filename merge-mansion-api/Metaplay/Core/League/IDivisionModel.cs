using Metaplay.Core.MultiplayerEntity;
using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System;

namespace Metaplay.Core.League
{
    [LeaguesEnabledCondition]
    public interface IDivisionModel : IMultiplayerModel, IModel, ISchemaMigratable
    {
        AnalyticsEventHandler<IDivisionModel, DivisionEventBase> AnalyticsEventHandler { get; set; }

        IDivisionModelServerListenerCore ServerListenerCore { get; }

        IDivisionModelClientListenerCore ClientListenerCore { get; }

        DivisionIndex DivisionIndex { get; set; }

        MetaTime StartsAt { get; set; }

        MetaTime EndsAt { get; set; }

        MetaTime EndingSoonStartsAt { get; set; }

        bool IsConcluded { get; set; }
    }

    public interface IDivisionModel<TDivisionModel> : IDivisionModel, IMultiplayerModel, IModel, ISchemaMigratable, IMultiplayerModel<TDivisionModel>, IModel<TDivisionModel>
    {
    }
}
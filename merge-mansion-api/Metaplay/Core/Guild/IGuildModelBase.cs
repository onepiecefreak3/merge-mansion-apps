using Metaplay.Core.MultiplayerEntity;
using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Guild
{
    public interface IGuildModelBase : IMultiplayerModel<IGuildModelBase>, IModel<IGuildModelBase>, IModel, ISchemaMigratable, IMultiplayerModel
    {
        AnalyticsEventHandler<IGuildModelBase, GuildEventBase> AnalyticsEventHandler { get; set; }

        IGuildModelServerListenerCore ServerListenerCore { get; set; }

        IGuildModelClientListenerCore ClientListenerCore { get; set; }

        GuildLifecyclePhase LifecyclePhase { get; set; }

        EntityId GuildId { get; set; }

        string DisplayName { get; set; }

        string Description { get; set; }

        int RunningMemberInstanceId { get; set; }

        Dictionary<EntityId, GuildPendingMemberKickState> PendingKicks { get; set; }

        bool IsNameSearchValid { get; set; }

        int RunningInviteId { get; set; }

        int MaxNumMembers { get; }

        int MemberCount { get; }

        GuildEventLog EventLog { get; }
    }
}
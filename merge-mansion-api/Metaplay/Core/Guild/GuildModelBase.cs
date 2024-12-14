using Metaplay.Core.Model;
using Metaplay.Core.MultiplayerEntity;
using System.Runtime.Serialization;
using System;
using Metaplay.Core.Config;
using Metaplay.Core.Analytics;
using System.Collections.Generic;

namespace Metaplay.Core.Guild
{
    [MetaReservedMembers(1, 100)]
    [MetaBlockedMembers(new int[] { 11 })]
    public abstract class GuildModelBase<TGuildModel, TGuildMember> : IGuildModel<TGuildModel>, IGuildModelBase, IMultiplayerModel<IGuildModelBase>, IModel<IGuildModelBase>, IModel, ISchemaMigratable, IMultiplayerModel
    {
        [IgnoreDataMember]
        public int LogicVersion { get; set; }

        [IgnoreDataMember]
        public ISharedGameConfig GameConfig { get; set; }

        [IgnoreDataMember]
        public LogChannel Log { get; set; }

        [IgnoreDataMember]
        public IGuildModelServerListenerCore ServerListenerCore { get; set; }

        [IgnoreDataMember]
        public IGuildModelClientListenerCore ClientListenerCore { get; set; }

        [IgnoreDataMember]
        public AnalyticsEventHandler<IGuildModelBase, GuildEventBase> AnalyticsEventHandler { get; set; }

        int Metaplay.Core.MultiplayerEntity.IMultiplayerModel.TicksPerSecond { get; }

        EntityId Metaplay.Core.MultiplayerEntity.IMultiplayerModel.EntityId { get; set; }
        public MetaTime CurrentTime { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Transient]
        public MetaTime TimeAtFirstTick { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Transient]
        public long CurrentTick { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EntityId GuildId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [ServerOnly]
        public GuildLifecyclePhase LifecyclePhase { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public Dictionary<EntityId, TGuildMember> Members { get; set; }

        [ServerOnly]
        [MetaMember(9, (MetaMemberFlags)0)]
        public Dictionary<EntityId, GuildPendingMemberKickState> PendingKicks { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [ServerOnly]
        public int RunningMemberInstanceId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [ServerOnly]
        public int RunningInviteId { get; set; }

        [PrettyPrint((PrettyPrintFlag)16)]
        [MetaMember(13, (MetaMemberFlags)0)]
        [ServerOnly]
        public GuildEventLog EventLog { get; set; }
        public int MemberCount { get; }
        public abstract int MaxNumMembers { get; }

        protected GuildModelBase()
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        [ServerOnly]
        public int SearchVersion { get; set; }
    }
}
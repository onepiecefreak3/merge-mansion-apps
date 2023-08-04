using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;
using Metaplay.Core.Config;

namespace Metaplay.Core.MultiplayerEntity
{
    [MetaReservedMembers(200, 300)]
    public abstract class MultiplayerModelBase<TModel> : IMultiplayerModel<TModel>, IModel<TModel>, IModel, ISchemaMigratable, IMultiplayerModel
    {
        [IgnoreDataMember]
        public int LogicVersion { get; set; }

        [IgnoreDataMember]
        public ISharedGameConfig GameConfig { get; set; }

        [IgnoreDataMember]
        public LogChannel Log { get; set; }

        [MetaMember(200, (MetaMemberFlags)0)]
        [Transient]
        public MetaTime TimeAtFirstTick { get; set; }

        [MetaMember(201, (MetaMemberFlags)0)]
        [Transient]
        public int CurrentTick { get; set; }

        [MetaMember(202, (MetaMemberFlags)0)]
        public EntityId EntityId { get; set; }

        [MetaMember(203, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [IgnoreDataMember]
        public abstract int TicksPerSecond { get; }
        public MetaTime CurrentTime { get; }

        protected MultiplayerModelBase()
        {
        }
    }
}
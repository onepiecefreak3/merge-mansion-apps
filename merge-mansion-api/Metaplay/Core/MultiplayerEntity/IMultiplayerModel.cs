using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Metaplay.Core.MultiplayerEntity
{
    public interface IMultiplayerModel : IModel, ISchemaMigratable
    {
        LogChannel Log { get; set; }

        ISharedGameConfig GameConfig { get; set; }

        MetaTime CreatedAt { get; set; }

        int TicksPerSecond { get; }

        MetaTime TimeAtFirstTick { get; }

        int CurrentTick { get; }

        EntityId EntityId { get; set; }

        MetaTime CurrentTime { get; }
    // STUB
    }

    public interface IMultiplayerModel<TModel> : IModel<TModel>, IModel, ISchemaMigratable, IMultiplayerModel
    {
    }
}
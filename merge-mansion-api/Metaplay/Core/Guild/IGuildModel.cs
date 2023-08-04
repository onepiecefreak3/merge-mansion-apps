using Metaplay.Core.MultiplayerEntity;
using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    public interface IGuildModel<TGuildModel> : IGuildModelBase, IMultiplayerModel<IGuildModelBase>, IModel<IGuildModelBase>, IModel, ISchemaMigratable, IMultiplayerModel
    {
    }
}
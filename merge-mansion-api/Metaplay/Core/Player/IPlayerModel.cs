using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    public interface IPlayerModel<TPlayerModel> : IPlayerModelBase, IModel<IPlayerModelBase>, IModel, ISchemaMigratable, IMetaIntegrationConstructible<IPlayerModelBase>, IMetaIntegration<IPlayerModelBase>, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
    }
}
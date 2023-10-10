namespace Metaplay.Core
{
    public interface IMetaIntegrationConstructible<T> : IMetaIntegration<T>, IMetaIntegration, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
    }

    public interface IMetaIntegrationConstructible : IRequireSingleConcreteType
    {
    }
}
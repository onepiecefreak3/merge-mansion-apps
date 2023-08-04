namespace Metaplay.Core
{
    public interface IMetaIntegrationConstructible<T> : IMetaIntegration<T>, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
    }

    public interface IMetaIntegrationConstructible : IRequireSingleConcreteType
    {
    }
}
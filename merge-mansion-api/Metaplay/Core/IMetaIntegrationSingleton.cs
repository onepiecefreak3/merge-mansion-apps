namespace Metaplay.Core
{
    public interface IMetaIntegrationSingleton<T> : IMetaIntegration<T>, IMetaIntegrationSingleton
    {
    }

    public interface IMetaIntegrationSingleton
    {
    }
}

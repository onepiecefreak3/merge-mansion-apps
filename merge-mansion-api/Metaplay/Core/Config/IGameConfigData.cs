namespace Metaplay.Core.Config
{
    public interface IGameConfigData<TKey> : IGameConfigData, IHasGameConfigKey<TKey>
    {
    }

    public interface IGameConfigData
    {
    }
}
namespace Metaplay.Core.Config
{
    public interface IGameConfigData<TKey> : IGameConfigData, IGameConfigKey<TKey>
    {
    }

    public interface IGameConfigData
    {
    }
}
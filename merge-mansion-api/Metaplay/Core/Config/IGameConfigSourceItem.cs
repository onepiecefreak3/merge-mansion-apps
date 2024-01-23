namespace Metaplay.Core.Config
{
    public interface IGameConfigSourceItem<TGameConfigData>
    {
    }

    public interface IGameConfigSourceItem<TGameConfigKey, TGameConfigData> : IGameConfigKey<TGameConfigKey>
    {
    }
}
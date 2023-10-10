namespace Metaplay.Core.Config
{
    public interface IGameConfigKey<TGameConfigKey>
    {
        TGameConfigKey ConfigKey { get; }
    }
}
namespace Metaplay.Core.Config
{
    public interface IHasGameConfigKey<TGameConfigKey>
    {
        TGameConfigKey ConfigKey { get; }
    }
}
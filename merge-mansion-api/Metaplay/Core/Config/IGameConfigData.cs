namespace Metaplay.Core.Config
{
    public interface IGameConfigData<TKey> : IGameConfigData
    {
        TKey ConfigKey { get; }
    }

	public interface IGameConfigData
    { }
}

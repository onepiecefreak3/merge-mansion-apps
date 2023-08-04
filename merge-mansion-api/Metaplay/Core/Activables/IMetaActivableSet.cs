namespace Metaplay.Core.Activables
{
    public interface IMetaActivableSet<TId, TInfo, TActivableState> : IMetaActivableSet<TId>, IMetaActivableSet
    {
    }

    public interface IMetaActivableSet<TId> : IMetaActivableSet
    {
    }

    public interface IMetaActivableSet
    {
    }
}
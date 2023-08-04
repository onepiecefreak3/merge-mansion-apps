namespace Metaplay.Core.Activables
{
    public interface IMetaActivableInfo
    {
        MetaActivableParams ActivableParams { get; }
    }

    public interface IMetaActivableInfo<TId> : IMetaActivableInfo
    {
        TId ActivableId { get; }
    }
}
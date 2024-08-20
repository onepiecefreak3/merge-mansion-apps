using Metaplay.Core.Model;

namespace Metaplay.Core.Client
{
    [MetaSerializable]
    public enum ChecksumGranularity
    {
        PerOperation = 0,
        PerBatch = 1,
        PerActionSingleTickPerFrame = 2,
        None = 3
    }
}
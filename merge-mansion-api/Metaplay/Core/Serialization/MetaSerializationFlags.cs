using Metaplay.Core.Model;

namespace Metaplay.Core.Serialization
{
    [MetaSerializable]
    public enum MetaSerializationFlags
    {
        IncludeAll = 0,
        SendOverNetwork = 1,
        ComputeChecksum = 2,
        Persisted = 4
    }
}
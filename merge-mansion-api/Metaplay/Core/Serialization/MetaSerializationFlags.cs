namespace Metaplay.Core.Serialization
{
    public enum MetaSerializationFlags
    {
        IncludeAll = 0,
        SendOverNetwork = 1,
        ComputeChecksum = 2,
        Persisted = 4
    }
}

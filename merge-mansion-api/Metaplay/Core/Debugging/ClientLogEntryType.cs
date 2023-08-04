using Metaplay.Core.Model;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public enum ClientLogEntryType
    {
        Log = 0,
        Warning = 1,
        Error = 2,
        Assert = 3,
        Exception = 4
    }
}
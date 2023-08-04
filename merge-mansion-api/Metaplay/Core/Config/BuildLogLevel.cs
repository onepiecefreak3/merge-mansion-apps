using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public enum BuildLogLevel
    {
        NotSet = 0,
        Verbose = 1,
        Debug = 2,
        Info = 3,
        Warning = 4,
        Error = 5
    }
}
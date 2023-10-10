using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public enum GameConfigBuildMessageLevel
    {
        NotSet = 0,
        Verbose = 1,
        Debug = 2,
        Information = 3,
        Warning = 4,
        Error = 5
    }
}
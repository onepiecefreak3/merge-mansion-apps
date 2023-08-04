using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public enum ConfigValidationType
    {
        Full = 0,
        BaselineOnly = 1
    }
}
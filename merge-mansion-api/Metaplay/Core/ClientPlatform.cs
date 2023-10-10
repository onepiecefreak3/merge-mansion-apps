using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public enum ClientPlatform
    {
        Unknown = 0,
        iOS = 1,
        Android = 2,
        WebGL = 3,
        UnityEditor = 4
    }
}
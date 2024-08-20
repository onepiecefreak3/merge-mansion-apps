using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum PlayerDeletionSource
    {
        Admin = 0,
        User = 1,
        System = 2,
        Unknown = 3
    }
}
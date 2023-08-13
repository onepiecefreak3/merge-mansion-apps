using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum ClientAppPauseStatus
    {
        Running = 0,
        Paused = 1,
        Unpausing = 2
    }
}
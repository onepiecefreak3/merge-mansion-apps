using Metaplay.Core.Model;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public enum GuildLifecyclePhase
    {
        WaitingForSetup = 0,
        WaitingForLeader = 1,
        Running = 2,
        Closed = 3
    }
}
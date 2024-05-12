using Metaplay.Core.Model;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    public enum PlayerLiveOpsEventUpdateType
    {
        PhaseChanged = 0,
        ForceUpdated = 1,
        AbruptlyRemoved = 2,
        ParamsUpdated = 3
    }
}
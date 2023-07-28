using System;

namespace Metaplay.Core.Network
{
    public enum ProtocolStatus
    {
        Pending = 0,
        InvalidGameMagic = 1,
        WireProtocolVersionMismatch = 2,
        ClusterRunning = 3,
        ClusterStarting = 4,
        ClusterShuttingDown = 5,
        [Obsolete("Please look for LoginMaintenanceFailure MetaMessage instead.")]
        InMaintenance = 6
    }
}

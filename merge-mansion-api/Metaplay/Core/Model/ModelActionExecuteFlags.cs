using System;

namespace Metaplay.Core.Model
{
    [Flags]
    public enum ModelActionExecuteFlags
    {
        None = 0,
        LeaderSynchronized = 1,
        FollowerSynchronized = 4,
        FollowerUnsynchronized = 8
    }
}
using System;

namespace Metaplay.Core.Model
{
    [Flags]
    public enum MetaMemberFlags
    {
        None = 0,
        Hidden = 1 << 0,
        NoChecksum = 1 << 1,
        Transient = 1 << 2,
        ExcludeFromGdprExport = 1 << 3,
        ServerOnly = Hidden | NoChecksum
    }
}
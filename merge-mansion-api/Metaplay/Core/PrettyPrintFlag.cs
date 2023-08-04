using System;

namespace Metaplay.Core
{
    [Flags]
    public enum PrettyPrintFlag
    {
        None = 0,
        SizeOnly = 1,
        Shorten = 4,
        Hide = 8,
        HideInDiff = 16
    }
}
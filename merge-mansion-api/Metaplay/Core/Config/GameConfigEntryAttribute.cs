using System;

namespace Metaplay.Core.Config
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GameConfigEntryAttribute : Attribute
    {
        // Fields
        public readonly string EntryName; // 0x10
        public readonly bool MpcFormat; // 0x18
        public readonly bool RequireArchiveEntry; // 0x19
        public readonly bool ResolveContainedMetaRefs; // 0x1A

        public GameConfigEntryAttribute(string entryName, bool mpcFormat = true, bool requireArchiveEntry = true,
            bool resolveContainedMetaRefs = true)
        {
            EntryName = entryName;
            MpcFormat = mpcFormat;
            RequireArchiveEntry = requireArchiveEntry;
            ResolveContainedMetaRefs = resolveContainedMetaRefs;
        }
    }
}

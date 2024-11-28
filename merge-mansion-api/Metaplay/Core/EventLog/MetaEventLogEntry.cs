using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;

namespace Metaplay.Core.EventLog
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class MetaEventLogEntry
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public int SequentialId { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public MetaTime CollectedAt { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public MetaUInt128 UniqueId { get; set; }

        public MetaEventLogEntry()
        {
        }

        public MetaEventLogEntry(MetaEventLogEntry.BaseParams baseParams)
        {
        }

        public readonly struct BaseParams
        {
            public readonly int SequentialId;
            public readonly MetaTime CollectedAt;
            public readonly MetaUInt128 UniqueId;
        }
    }
}
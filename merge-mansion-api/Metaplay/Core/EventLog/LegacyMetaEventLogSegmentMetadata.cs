using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    public struct LegacyMetaEventLogSegmentMetadata
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SegmentSequentialId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int StartEntryId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int NumEntries { get; set; }
    }
}
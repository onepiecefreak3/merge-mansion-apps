using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    public abstract class MetaEventLog<TEntry>
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public int RunningEntryId;
        [MetaMember(101, (MetaMemberFlags)0)]
        public List<TEntry> LatestSegmentEntries;
        [MetaMember(103, (MetaMemberFlags)0)]
        public int RunningSegmentId;
        [MetaMember(105, (MetaMemberFlags)0)]
        public List<MetaEventLog<TEntry>> PendingSegments;
        [MetaMember(106, (MetaMemberFlags)0)]
        public int OldestAvailableSegmentId;
        [MetaMember(104, (MetaMemberFlags)0)]
        private List<LegacyMetaEventLogSegmentMetadata> _legacyPersistedSegmentMetadatas;
        public int NumAvailablePersistedSegments { get; }

        protected MetaEventLog()
        {
        }

        [MetaSerializable]
        public class PendingSegment<TEntry>
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public List<TEntry> Entries;
            private PendingSegment()
            {
            }

            public PendingSegment(List<TEntry> entries)
            {
            }
        }
    }
}
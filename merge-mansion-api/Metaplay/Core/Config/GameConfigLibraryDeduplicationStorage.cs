using Metaplay.Core.Player;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public class GameConfigLibraryDeduplicationStorage<TKey, TInfo> : IGameConfigLibraryDeduplicationStorage
    {
        public Dictionary<ExperimentVariantPair, ConfigPatchIndex> PatchIdToIndex;
        public Dictionary<ConfigPatchIndex, ExperimentVariantPair> PatchIndexToId;
        public Dictionary<TKey, GameConfigLibraryPatchedItemEntry<TInfo>> PatchedItemEntries;
        public int NumBaselineItems;
        public Dictionary<ConfigPatchIndex, GameConfigLibraryDeduplicationStorage<TKey, TInfo>> PatchInfos;
        public GameConfigLibraryDeduplicationStorage(IEnumerable<ExperimentVariantPair> allPatchIds)
        {
        }

        public class PatchInfo<TKey, TInfo>
        {
            public HashSet<TKey> DirectlyPatchedItems;
            public HashSet<TKey> IndirectlyPatchedItems;
            public HashSet<TKey> AppendedItems;
            public PatchInfo()
            {
            }
        }

        public int NumSinglePatchDirectlyDuplicatedItems { get; }
        public int NumSinglePatchIndirectlyDuplicatedItems { get; }
    }
}
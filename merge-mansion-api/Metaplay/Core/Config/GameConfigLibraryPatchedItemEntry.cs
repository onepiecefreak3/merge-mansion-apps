using System.Collections.Generic;
using System;

namespace Metaplay.Core.Config
{
    public class GameConfigLibraryPatchedItemEntry<TInfo>
    {
        public GameConfigLibraryPatchedItemEntry<TInfo> BaselineMaybe;
        public List<GameConfigLibraryPatchedItemEntry<TInfo>> PatchOverridesMaybe;
        public GameConfigLibraryPatchedItemEntry(GameConfigLibraryPatchedItemEntry<TInfo> baselineMaybe, List<GameConfigLibraryPatchedItemEntry<TInfo>> patchOverridesMaybe)
        {
        }

        public class ItemData<TInfo>
        {
            public TInfo Item;
            public HashSet<ConfigItemId> ReferencesFromThisItemMaybe;
            public ItemData(TInfo item, HashSet<ConfigItemId> referencesFromThisItemMaybe)
            {
            }
        }

        public class PatchOverride<TInfo>
        {
            public ConfigPatchIndex PatchIndex;
            public GameConfigLibraryPatchedItemEntry<TInfo> Data;
            public bool IsDirectlyPatched;
            public PatchOverride(ConfigPatchIndex patchIndex, GameConfigLibraryPatchedItemEntry<TInfo> data, bool isDirectlyPatched)
            {
            }
        }
    }
}
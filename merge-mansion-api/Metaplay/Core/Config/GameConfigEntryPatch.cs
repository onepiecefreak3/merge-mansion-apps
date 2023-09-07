using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    public abstract class GameConfigEntryPatch
    {
        protected GameConfigEntryPatch()
        {
        }

        internal abstract void PatchContentDangerouslyInPlace(object entryContent);
    }

    [MetaSerializable]
    public abstract class GameConfigEntryPatch<TEntry, TEntryContent> : GameConfigEntryPatch
    {
        protected GameConfigEntryPatch()
        {
        }

        internal sealed override void PatchContentDangerouslyInPlace(object entryContent)
        {
            PatchContentDangerouslyInPlace((TEntryContent)entryContent);
        }

        internal abstract void PatchContentDangerouslyInPlace(TEntryContent entryContent);
    }
}
using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    public abstract class GameConfigEntryPatch
    {
        protected GameConfigEntryPatch()
        {
        }
    }

    [MetaSerializable]
    public abstract class GameConfigEntryPatch<TEntry, TEntryContent> : GameConfigEntryPatch
    {
        protected GameConfigEntryPatch()
        {
        }
    }
}
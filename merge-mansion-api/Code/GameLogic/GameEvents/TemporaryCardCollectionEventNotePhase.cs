using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum TemporaryCardCollectionEventNotePhase
    {
        Preview = 0,
        Start = 1,
        End = 2
    }
}
using Metaplay.Core.Model;

namespace GameLogic.Player.Events
{
    [MetaSerializable]
    public enum CardCollectionSupportingEventNotePhase
    {
        Preview = 0,
        Start = 1,
        End = 2
    }
}
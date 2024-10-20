using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum ProgressionEventNotePhase
    {
        Start = 0,
        End = 1,
        Streak = 2,
        BonusRewards = 3
    }
}
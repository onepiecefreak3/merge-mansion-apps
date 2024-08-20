using Metaplay.Core.Model;

namespace GameLogic.Player.Events
{
    [MetaSerializable]
    public enum SoloMilestoneCompletionState
    {
        None = 0,
        TriggerPopup = 1,
        PopupShown = 2
    }
}
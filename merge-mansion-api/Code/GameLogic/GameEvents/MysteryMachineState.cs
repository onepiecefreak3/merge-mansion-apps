using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum MysteryMachineState
    {
        NotStarted = 0,
        Preparing = 1,
        Started = 2,
        CompleteTasks = 3,
        ClaimAllTasksCompletedReward = 4
    }
}
using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum MergeResult
    {
        Nothing = 0,
        InvalidPosition = 1,
        Move = 2,
        MergeHappens = 3,
        Swap = 4,
        SinkEats = 5,
        Consumed = 6,
        MergeCapReached = 7,
        InsufficientMergeChainLevel = 8,
        TakePhoto = 9,
        PhotoOfItemAlreadyTaken = 10,
        SinkEatsReverse = 11,
        ActivatePrisonCell = 12,
        PrisonCellAlreadyActivated = 13,
        GreatEscapeMinigameActivated = 14,
        GreatEscapePostBoxSank = 15
    }
}
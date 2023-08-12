using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public enum BuildLogCode
    {
        None = 0,
        Reserved = 999,
        IncompleteValidation = 1000,
        MissingItem = 1001,
        NoItemsInMergeChain = 1002,
        MergeChainAndItemDontMatch = 1003,
        NonPositiveCost = 1004,
        MergeChainNotDefined = 1005,
        InitialTaskMissing = 1006,
        BoardEventMissingTasks = 1007,
        DialogueItemNotUsed = 1008,
        MergeChainMissingMember = 1009,
        ProgressionEventMissingLevels = 1010,
        ProgressionEventLevelCountMismatch = 1011,
        ProgressionEventLevelRequiredPointsMismatch = 1012,
        ProgressionEventPopupDialogueMissingTriggerPopupAction = 1013,
        StorageActionPreserveRatioHowManyInCyclesMismatch = 1014,
        MissingHardcodedMember = 1015,
        UnreachableHotspots = 1016,
        SeasonalEventSegmentsMismatch = 1017,
        SeasonalEventUnlockRequirementMismatch = 1018,
        ActivableScheduleExpired = 1019,
        OrphanedOffer = 1020,
        BoardEventPortalItemTaskMismatch = 1021,
        MissingLeaderboardEventRankingRewardTag = 1022
    }
}
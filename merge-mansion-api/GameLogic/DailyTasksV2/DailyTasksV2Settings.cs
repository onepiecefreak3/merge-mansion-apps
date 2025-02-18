using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;
using System;
using Metaplay.Core.Math;

namespace GameLogic.DailyTasksV2
{
    [MetaBlockedMembers(new int[] { 3 })]
    [MetaSerializable]
    public class DailyTasksV2Settings : GameConfigKeyValue<DailyTasksV2Settings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MetaRef<DailyTasksV2CompletionRewardInfo>> CompletionRewards { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CycleResetHourUtc { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int TimeExtensionMaxConsecutiveCount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int TimeExtensionMinHours { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<int> TimeExtensionPriceInDiamonds { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<int> AgeValues { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int NextHotspotsCount { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int MaxStreakCount { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public F32 MaxDiminishingPercentageForOldRequirements { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int LastGeneratedTaskRewardItemsHistoryCountMaxSize { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public FillStepPriceMode TaskBuyoutPriceMode { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public int MaxLevelDifferenceFromHotspotToRemoveRequirementItem { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public List<string> AlgorithmAttemptsDefault { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public int SortingRangeForPossibleRequirementsHighPriority { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public int SortingRangeGeneric { get; set; }

        public DailyTasksV2Settings()
        {
        }

        [MetaMember(17, (MetaMemberFlags)0)]
        public int TimeExtensionTimeWindowMaxHours { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public F32 MaxRewardRequirementRatioForLowLow { get; set; }
    }
}
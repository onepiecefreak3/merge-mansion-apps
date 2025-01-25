using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Player.Items;
using GameLogic.DailyTasksV2;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTasksV2Status
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string TasksSetId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public MetaTime StartTime { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime EndTime { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(4, (MetaMemberFlags)0)]
        public List<DailyTaskV2State> Tasks { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int ConsecutiveTimeExtensionCount { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(6, (MetaMemberFlags)0)]
        public bool HasPendingFirstImpression { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public bool IsCompletionResolved { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int LastResolvedConsecutiveTimeExtensionNumber { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int StreakCount { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string AlgorithmLogContent { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(11, (MetaMemberFlags)0)]
        public bool DidOpenPopupAtLeastOnce { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string LastGeneratedTaskVisibleHotspotHash { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public List<MetaRef<ItemDefinition>> LastGeneratedTaskRewardItemsHistory { get; set; }

        public DailyTasksV2Status()
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public Dictionary<DailyTaskV2Id, DailyTaskV2StateCustomizationForBoultonLeague> BoultonLeagueTasksCustomizations { get; set; }
    }
}
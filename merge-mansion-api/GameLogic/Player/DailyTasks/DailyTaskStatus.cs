using Metaplay.Core.Model;
using System.Reflection;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;
using System.Runtime.Serialization;

namespace GameLogic.Player.DailyTasks
{
    [MetaSerializable]
    [DefaultMember("Item")]
    [MetaBlockedMembers(new int[] { 1, 2, 3, 7, 9, 10 })]
    public class DailyTaskStatus
    {
        [MetaMember(15, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int Level;
        [ExcludeFromGdprExport]
        [MetaMember(16, (MetaMemberFlags)0)]
        public int Points;
        [ExcludeFromGdprExport]
        [MetaMember(17, (MetaMemberFlags)0)]
        public int LastSeenPoints;
        [ExcludeFromGdprExport]
        [MetaMember(18, (MetaMemberFlags)0)]
        public int LastSeenLevel;
        [MetaMember(19, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public bool IsUsingEventLevels;
        [MetaMember(4, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private MetaRef<ItemDefinition> TotalCompleteRewardItem { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(5, (MetaMemberFlags)0)]
        private int TotalCompleteRewardAmount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public MetaTime StartTime { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(8, (MetaMemberFlags)0)]
        private List<DailyTaskState> States { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(11, (MetaMemberFlags)0)]
        public bool PendingFirstImpressionAnalytics { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(12, (MetaMemberFlags)0)]
        public string DailyTasksSetId { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(13, (MetaMemberFlags)0)]
        private int CompletedTasksForFinalReward { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaRef<EventLevels> Levels { get; set; }

        [IgnoreDataMember]
        public DailyTaskState Item { get; }

        [IgnoreDataMember]
        public int TasksCount { get; }

        [IgnoreDataMember]
        public IEnumerable<DailyTaskState> TaskStates { get; }

        [IgnoreDataMember]
        public ItemDefinition FinalReward { get; }

        [IgnoreDataMember]
        public int FinalRewardQuantity { get; }

        [IgnoreDataMember]
        public EventId EventId { get; }

        public DailyTaskStatus()
        {
        }
    }
}
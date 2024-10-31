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
    [MetaBlockedMembers(new int[] { 1, 2, 3, 4, 5, 7, 9, 10, 13, 19 })]
    public class DailyTaskStatus
    {
        [MetaMember(15, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int Level;
        [MetaMember(16, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int Points;
        [MetaMember(17, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int LastSeenPoints;
        [ExcludeFromGdprExport]
        [MetaMember(18, (MetaMemberFlags)0)]
        public int LastSeenLevel;
        [ExcludeFromGdprExport]
        [MetaMember(6, (MetaMemberFlags)0)]
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
        [MetaMember(14, (MetaMemberFlags)0)]
        public MetaRef<EventLevels> Levels { get; set; }

        [IgnoreDataMember]
        public DailyTaskState Item { get; }

        [IgnoreDataMember]
        public int TasksCount { get; }

        [IgnoreDataMember]
        public IEnumerable<DailyTaskState> TaskStates { get; }

        [IgnoreDataMember]
        public EventId EventId { get; }

        public DailyTaskStatus()
        {
        }

        public bool AllTasksComplete { get; }

        [ExcludeFromGdprExport]
        [MetaMember(20, (MetaMemberFlags)0)]
        public int AllTimeRefreshPurchasesCount { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int DailyRefreshPurchasesCount { get; set; }
    }
}
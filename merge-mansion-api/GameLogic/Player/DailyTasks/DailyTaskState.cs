using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;
using GameLogic.DailyTasks;

namespace GameLogic.Player.DailyTasks
{
    [MetaSerializable]
    public class DailyTaskState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> RequiredItemRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RequiredQuantity { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> ResultingItemRef { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int ResultingQuantity { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public OverrideItemFeatures ResultingItemOverrideFeatures { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaTime? TimeTaskCompleted { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public DailyTaskId DailyTaskId { get; set; }
        public ItemDefinition RequiredItem { get; }
        public ItemDefinition ResultingItem { get; }
        public bool IsComplete { get; }

        private DailyTaskState()
        {
        }

        public DailyTaskState(int requiredItem, int requiredQuantity, int resultingItem, int resultingQuantity)
        {
        }

        public DailyTaskState(DailyTaskDefinition definition)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public MetaTime? TimeTaskWasPurchased { get; set; }
        public bool IsPurchasedTask { get; }

        public DailyTaskState(DailyTaskDefinition definition, MetaTime timeTaskWasPurchased)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.DynamicEvents
{
    [MetaSerializable]
    public class DebugItemData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TaskId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string GeneratedItem;
        [MetaMember(3, (MetaMemberFlags)0)]
        public string FirstItemInTopTask;
        [MetaMember(4, (MetaMemberFlags)0)]
        public string RequiredItemsInSameTask;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string RequiredItemsInOtherTasks;
        [MetaMember(6, (MetaMemberFlags)0)]
        public string RequiredItemsInAreaTasks;
        [MetaMember(7, (MetaMemberFlags)0)]
        public string ItemsInBoard;
        [MetaMember(8, (MetaMemberFlags)0)]
        public string ItemsInInventories;
        [MetaMember(9, (MetaMemberFlags)0)]
        public string FinalPoolOfItemsWithWeights;
        [MetaMember(10, (MetaMemberFlags)0)]
        public string TaskRewards;
        public DebugItemData()
        {
        }
    }
}
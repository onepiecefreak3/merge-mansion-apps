using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.DailyTasks;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;
using Metaplay.Core.Math;

namespace GameLogic
{
    [MetaSerializable]
    public class DailyTaskDefinition : IGameConfigData<DailyTaskId>, IGameConfigData, IHasGameConfigKey<DailyTaskId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyTaskId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Type { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int StartLevel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int EndLevel { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> RequiredItemType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int RequiredItemsAmount { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> RewardItemType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int RewardItemAmount { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public OverrideItemFeatures RewardOverrideItemFeatures { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public F32 InitialWeight { get; set; }

        public DailyTaskDefinition()
        {
        }

        public DailyTaskDefinition(int startLevel, int endLevel, int itemId, int amount, int reward, int resultMulti)
        {
        }

        public DailyTaskDefinition(DailyTaskId taskId, string poolType, int startLevel, int endLevel, MetaRef<ItemDefinition> requiredItemRef, int requiredItemAmount, MetaRef<ItemDefinition> rewardItemRef, int rewardAmount, OverrideItemFeatures rewardOverrideItemFeatures, F32 initialWeight)
        {
        }
    }
}
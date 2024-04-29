using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System;
using Metaplay.Core;
using Metaplay.Core.Math;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineInfo : IGameConfigData<MysteryMachineId>, IGameConfigData, IHasGameConfigKey<MysteryMachineId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ItemCapacity { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineItemSetInfo> ItemSetRef { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineItemSetInfo> InitialSpawnOrderItemSetRef { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public F32 Width { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineHeatLevelInfo>> HeatLevelRefs { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int CoughsPerHeatLevel { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public F32 MaxMergeDuration { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public F32 MinMergeDuration { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public F32 MergeDurationDecreasePerMerge { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public F32 MaxDelayBetweenMerges { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public F32 MinDelayBetweenMerges { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public F32 DelayDecreasePerMerge { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public MysteryMachineDurationDelayResetStyle DurationDelayResetStyle { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineSpecialSaleInfo>> SpecialSaleRefs { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public int MaxSpecialSalePurchaseCount { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineTaskSetInfo>> TaskSetRefs { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public PlayerReward AllTasksCompletedReward { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public List<F64> OverheatBaseScoreMultiplierIncreases { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineLevelInfo>> LevelRefs { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineTaskInfo>> RecurringTaskRefs { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public int FtueMachineRestartLimit { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public List<int> FtueCoughStates { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public List<int> FtueItemSpawnCounts { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public List<int> EnergyPurchasePrices { get; set; }

        public MysteryMachineInfo()
        {
        }

        public MysteryMachineInfo(MysteryMachineId configKey, int itemCapacity, MetaRef<MysteryMachineItemSetInfo> itemSetRef, MetaRef<MysteryMachineItemSetInfo> initialSpawnOrderItemSetRef, F32 width, List<MetaRef<MysteryMachineHeatLevelInfo>> heatLevelRefs, int coughsPerHeatLevel, F32 maxMergeDuration, F32 minMergeDuration, F32 mergeDurationDecreasePerMerge, F32 maxDelayBetweenMerges, F32 minDelayBetweenMerges, F32 delayDecreasePerMerge, MysteryMachineDurationDelayResetStyle durationDelayResetStyle, List<MetaRef<MysteryMachineSpecialSaleInfo>> specialSaleRefs, int maxSpecialSalePurchaseCount, List<MetaRef<MysteryMachineTaskSetInfo>> taskSetRefs, PlayerReward allTasksCompletedReward, List<F64> overheatBaseScoreMultiplierIncreases, List<MetaRef<MysteryMachineLevelInfo>> levelRefs, List<MetaRef<MysteryMachineTaskInfo>> recurringTaskRefs, int ftueMachineRestartLimit, List<int> ftueCoughStates, List<int> ftueItemSpawnCounts, List<int> energyPurchasePrices)
        {
        }
    }
}
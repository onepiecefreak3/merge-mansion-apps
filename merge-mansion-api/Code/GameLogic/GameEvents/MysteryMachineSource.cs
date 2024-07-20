using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using Metaplay.Core.Math;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineSource : IConfigItemSource<MysteryMachineInfo, MysteryMachineId>, IGameConfigSourceItem<MysteryMachineId, MysteryMachineInfo>, IHasGameConfigKey<MysteryMachineId>
    {
        public MysteryMachineId ConfigKey { get; set; }
        private int ItemCapacity { get; set; }
        private MetaRef<MysteryMachineItemSetInfo> ItemSet { get; set; }
        private MetaRef<MysteryMachineItemSetInfo> InitialSpawnOrderItemSet { get; set; }
        private F32 Width { get; set; }
        private List<MetaRef<MysteryMachineHeatLevelInfo>> HeatLevels { get; set; }
        private int CoughsPerHeatLevel { get; set; }
        private F32 MaxMergeDuration { get; set; }
        private F32 MinMergeDuration { get; set; }
        private F32 MergeDurationDecreasePerMerge { get; set; }
        private F32 MaxDelayBetweenMerges { get; set; }
        private F32 MinDelayBetweenMerges { get; set; }
        private F32 DelayDecreasePerMerge { get; set; }
        private MysteryMachineDurationDelayResetStyle DurationDelayResetStyle { get; set; }
        private List<MetaRef<MysteryMachineSpecialSaleInfo>> SpecialSales { get; set; }
        private int MaxSpecialSalePurchaseCount { get; set; }
        private List<MetaRef<MysteryMachineTaskSetInfo>> TaskSets { get; set; }
        private List<F64> OverheatBaseScoreMultiplierIncreases { get; set; }
        private List<MetaRef<MysteryMachineLevelInfo>> Levels { get; set; }
        private List<MetaRef<MysteryMachineTaskInfo>> RecurringTasks { get; set; }
        private int FTUEMachineRestartLimit { get; set; }
        private List<int> FTUECoughState { get; set; }
        private List<int> FTUEItemSpawnCounts { get; set; }
        private List<int> EnergyPurchasePrices { get; set; }
        private string AllTasksCompletedRewardType { get; set; }
        private string AllTasksCompletedRewardId { get; set; }
        private string AllTasksCompletedRewardAux0 { get; set; }
        private string AllTasksCompletedRewardAux1 { get; set; }
        private int AllTasksCompletedRewardAmount { get; set; }

        public MysteryMachineSource()
        {
        }

        private string SecondaryAllTasksCompletedRewardType { get; set; }
        private string SecondaryAllTasksCompletedRewardId { get; set; }
        private string SecondaryAllTasksCompletedRewardAux0 { get; set; }
        private string SecondaryAllTasksCompletedRewardAux1 { get; set; }
        private int SecondaryAllTasksCompletedRewardAmount { get; set; }
        private WeightsType WeightsType { get; set; }
    }
}
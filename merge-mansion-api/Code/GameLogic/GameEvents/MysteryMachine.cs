using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Metaplay.Core.Math;
using Metaplay.Core;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachine
    {
        public static int InitialHeatLevel;
        public static int InitialLevel;
        public static int MaxScore;
        [IgnoreDataMember]
        private List<int> freeSaleItemWeights;
        [IgnoreDataMember]
        public MysteryMachineEventInfo MysteryMachineEventInfo;
        [IgnoreDataMember]
        public MysteryMachineInfo MysteryMachineInfo;
        [MetaMember(1, (MetaMemberFlags)0)]
        private MysteryMachineEventId MysteryMachineEventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MysteryMachineId MysteryMachineId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MysteryMachineContainerItemData> ContainerItems { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private int TotalSpawnedItemsCount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int HeatLevel { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int CoughCount { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private IMysteryMachineItem PreviousMergeResult { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private int PreviousMergeResultIndex { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int Score { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public F64 ScoreMultiplier { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        private Dictionary<string, int> MinLevelsByChainId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        private List<int> SpawnCountWeights { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public IMysteryMachineItem NextItem { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public int JackpotMultiplier { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public Dictionary<MysteryMachineSpecialSaleId, int> SpecialSaleCostSteps { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public MysteryMachineMultiplierInfo RunningChainMultiplier { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public MysteryMachineState State { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        private Dictionary<MysteryMachineSpecialSaleId, int> SpecialSaleFreeItems { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public int HighScore { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public ulong TotalScore { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public F64 BaseScoreMultiplier { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public List<int> HeatLevelScores { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public Dictionary<int, int> CurrentTaskItemsSpawned { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public Dictionary<MysteryMachineTaskSetId, List<MysteryMachineTaskId>> CompletedTasksByTaskSet { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public int OverheatCount { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public Dictionary<string, int> ExtraItemGrants { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        public Dictionary<MysteryMachineTaskId, ulong> CurrentTaskTotalScores { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        public bool AllTasksCompletedRewardClaimed { get; set; }

        [MetaMember(30, (MetaMemberFlags)0)]
        public int StartCount { get; set; }

        [MetaMember(31, (MetaMemberFlags)0)]
        public int Level { get; set; }

        [MetaMember(32, (MetaMemberFlags)0)]
        public Dictionary<MysteryMachineTaskId, int> RecurringTasksCompleted { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        public List<IMysteryMachineItem> SpawnItemsQueue { get; set; }

        [MetaMember(34, (MetaMemberFlags)0)]
        public MysteryMachineSpecialSaleId LatestFreeSpecialSaleItem { get; set; }

        [MetaMember(35, (MetaMemberFlags)0)]
        private int TotalSpawnInitiationCount { get; set; }

        [MetaMember(36, (MetaMemberFlags)0)]
        private int RunSpawnInitiationCount { get; set; }

        [MetaMember(37, (MetaMemberFlags)0)]
        public int ContinuesPurchased { get; set; }

        [MetaMember(38, (MetaMemberFlags)0)]
        private Dictionary<string, int> RunSpawnItems { get; set; }

        [MetaMember(39, (MetaMemberFlags)0)]
        private Dictionary<string, int> RunSpecialSaleDiamonds { get; set; }

        [MetaMember(40, (MetaMemberFlags)0)]
        private Dictionary<string, int> RunSpecialSaleFree { get; set; }

        [MetaMember(41, (MetaMemberFlags)0)]
        public HashSet<MysteryMachineTaskId> TasksAcknowledged { get; set; }

        [MetaMember(42, (MetaMemberFlags)0)]
        public MetaTime RunStartTime { get; set; }

        private MysteryMachine()
        {
        }

        public MysteryMachine(IPlayer player, MysteryMachineEventInfo mysteryMachineEventInfo, MysteryMachineInfo mysteryMachineInfo)
        {
        }

        [MetaMember(43, (MetaMemberFlags)0)]
        public int RunDiamondsSpentOnMachineEnergy { get; set; }

        [MetaMember(44, (MetaMemberFlags)0)]
        public bool NewHighScore { get; set; }

        [MetaMember(45, (MetaMemberFlags)0)]
        public int FinishCount { get; set; }

        [MetaMember(46, (MetaMemberFlags)0)]
        public int? FinishedHighScore { get; set; }

        [MetaMember(47, (MetaMemberFlags)0)]
        public int? SubmittedLeaderboardHighScore { get; set; }

        [MetaMember(48, (MetaMemberFlags)0)]
        public bool SubmittedNewLeaderboardHighScore { get; set; }
    }
}
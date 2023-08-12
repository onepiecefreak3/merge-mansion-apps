using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic.Player.Director.Config;
using Metaplay.Core.Math;
using Merge;
using Code.GameLogic.GameEvents;

namespace GameLogic.Config
{
    [MetaBlockedMembers(new int[] { 1, 2, 3 })]
    [MetaSerializable]
    public class SharedGlobals : GameConfigKeyValue<SharedGlobals>
    {
        [MetaMember(4, (MetaMemberFlags)0)]
        public int DefaultActivationCost { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaDuration EnergyUnitRestoreDuration { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<string> ItemTagsRequiringBoosterAnalytics { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<IDirectorAction> StartupActions { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public CollectItemsOnSessionStartSettings AutoCollectOnSessionStarted { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<int> ProgressionEventBlackListedItems { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<string> ItemTagsIgnoredByItemInfoPopup { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public StartingValues StartingValues { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public List<string> ItemTagsIgnoredByLocalizationValidation { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public SpeedUpCostBehavior SpeedUpCostBehavior { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public SpeedUpBehavior SpeedUpBehavior { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public List<int> ItemSellPrices { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public MetaDuration SecondaryEnergyUnitRestoreDuration { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public long SecondaryEnergyMaxAmount { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public int PlayerNamePopupTriggerLevel { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public bool ValidatePlayerNameOnInputEnd { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public F32 DailyTaskWeightAdditive { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public F32 DailyTaskWeightMultiplicative { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public F32 DailyTaskWeightSubtractive { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public F32 DailyTasksCount { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public MergeBoardId InitBoardId { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public bool ProgressionEventBubbleBonusesEnabled { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public bool ForcePlayerName { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public MetaDuration DialogueInputDelay { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        public string PlayerNameDisallowedRegex { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        public MetaDuration DailyTasksDuration { get; set; }

        [MetaMember(30, (MetaMemberFlags)0)]
        public int DailyTasksResetHourUTC { get; set; }

        [MetaMember(31, (MetaMemberFlags)0)]
        public bool DailyTasksRefreshTogetherWithFinalReward { get; set; }

        [MetaMember(32, (MetaMemberFlags)0)]
        public int DailyTasksRequiredTasksForFinalReward { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevels>> DailyTasksEventLevelSets { get; set; }

        public SharedGlobals()
        {
        }

        [MetaMember(34, (MetaMemberFlags)0)]
        public long MergeHintWaitTimeMilliseconds { get; set; }

        [MetaMember(35, (MetaMemberFlags)0)]
        public List<int> DailyTasksRefreshPricesInDiamonds { get; set; }

        [MetaMember(36, (MetaMemberFlags)0)]
        public int DailyTasksRefreshTasksCount { get; set; }

        [MetaMember(37, (MetaMemberFlags)0)]
        public bool DailyTasksRefreshAlsoOnFinalReward { get; set; }

        [MetaMember(38, (MetaMemberFlags)0)]
        public int ItemsNeededCountDisplayMax { get; set; }
    }
}
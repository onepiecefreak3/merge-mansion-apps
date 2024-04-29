using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Config;
using GameLogic.Decorations;
using Metaplay.Core;
using GameLogic.Player.Items;
using Merge;
using GameLogic.MergeChains;
using GameLogic.Area;
using GameLogic.Player.Items.Merging;
using Code.GameLogic.GameEvents;
using System.Runtime.Serialization;
using GameLogic;
using Metaplay.Core.Math;
using GameLogic.Seasonality;
using GameLogic.Player.Rewards;
using GameLogic.Player.Requirements;
using Code.GameLogic.DynamicEvents;
using GameLogic.Hotspots.CardStack;

namespace Game.Logic
{
    [MetaBlockedMembers(new int[] { 1, 10, 11, 15, 16, 20, 21, 23, 28, 35, 36, 37, 38, 39, 41, 44 })]
    [MetaSerializable]
    public class ProgressState
    {
        public Action OnUndoSellItemCleared;
        public ItemDiscoveredEvent ItemDiscovered;
        [MetaMember(40, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<HotspotId> FinalizedHotspots;
        private static DirectorGroupId notificationsGroupId;
        public CharacterDiscoveredEvent CharacterDiscovered;
        private int lastVisibleHotpotChangedHash;
        private static char animationSplitChar;
        public static DecorationId DecorationNone;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int playerLevel { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> legacyEventGroupsCompleted { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(4, (MetaMemberFlags)0)]
        private HashSet<HotspotId> visibleHotspots { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(5, (MetaMemberFlags)0)]
        private HashSet<HotspotId> completedHotspots { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<string, string> storedAnimationStates { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<int> discoveredItemTypes { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private Dictionary<int, int> boughtBoxAmounts { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(9, (MetaMemberFlags)0)]
        private RandomPCG random { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(12, (MetaMemberFlags)0)]
        private MetaTime endTimeOfCurrentEventBoard { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private int currentEventBoardAdventureStep { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [NoChecksum]
        [ExcludeFromGdprExport]
        private CalendarBoardEventStatus currentEventBoardStatus { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private MergeItem undoItemSellItem { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(18, (MetaMemberFlags)0)]
        private int undoItemSellCoordinateX { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private int undoItemSellCoordinateY { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        private HashSet<MassMailIdenfiers> addedMassEmails { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private bool isInventoryAvailable { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<string> ownedDecorations { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(26, (MetaMemberFlags)0)]
        private List<string> visibleDecorations { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(27, (MetaMemberFlags)0)]
        private MergeBoardId undoBoardId { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private MergeBoardId currentEventBoardId2 { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(30, (MetaMemberFlags)0)]
        private Dictionary<MergeBoardId, long> nextPossibleEventReplayDay2 { get; set; }

        [MetaMember(31, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<MergeBoardId, int> eventProgressValues2 { get; set; }

        [MetaMember(32, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<MergeBoardId, int> eventStartedTimes2 { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<string> eventsStartedAtLeastOnce { get; set; }

        [MetaMember(34, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<string, string> storedUnityAnimationStates { get; set; }

        [MetaMember(42, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<int> claimedDiscoveryRewards { get; set; }

        [MetaMember(43, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<MergeChainId> claimedDiscoveryCompletionRewards { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(45, (MetaMemberFlags)0)]
        private HashSet<AreaId> completedAreas { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(46, (MetaMemberFlags)0)]
        private HashSet<MergeRewardId> CollectedMergeRewards { get; set; }

        [MetaMember(47, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<AreaId> notedTeasedAreas { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(48, (MetaMemberFlags)0)]
        private HashSet<EventOfferSetId> claimedEventOfferSets { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(49, (MetaMemberFlags)0)]
        private HashSet<DirectorGroupId> eventGroupsCompleted { get; set; }

        [MetaMember(50, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<EventId> acknowledgedShopEvents { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(51, (MetaMemberFlags)0)]
        private Dictionary<MergeChainId, int> mergeChainLevels { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(52, (MetaMemberFlags)0)]
        private HashSet<DialogCharacterType> discoveredCharacterTypes { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(53, (MetaMemberFlags)0)]
        private Dictionary<LayeredDecorationSetId, int> layeredDecorationProgress { get; set; }

        [MetaMember(54, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<string, DecorationId> visibleEventDecorations { get; set; }

        [MetaMember(55, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<string, HotspotId> visibleEventHotspots { get; set; }

        [IgnoreDataMember]
        public IEnumerable<int> DiscoveredItems { get; }
        public IEnumerable<string> DiscoveredItemTypeStrings { get; }

        public ProgressState()
        {
        }

        [ExcludeFromGdprExport]
        [MetaMember(56, (MetaMemberFlags)0)]
        private Dictionary<int, F32> itemWeightRecords { get; set; }

        [MetaMember(57, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<int> photoTakenItems { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(58, (MetaMemberFlags)0)]
        private Dictionary<int, int> itemCaughtCount { get; set; }

        public ItemUnlockedEvent ItemUnlocked;
        [ExcludeFromGdprExport]
        [MetaMember(59, (MetaMemberFlags)0)]
        public List<int> UnclaimedWorldRecordRewardFishes { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(60, (MetaMemberFlags)0)]
        public Dictionary<int, HashSet<int>> ClaimedWeightStarRewards { get; set; }

        [MetaMember(61, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private HashSet<SeasonId> seasonsDiscovered { get; set; }

        [IgnoreDataMember]
        public IEnumerable<SeasonId> SeasonsDiscovered { get; }

        [MetaMember(63, (MetaMemberFlags)0)]
        private Dictionary<HotspotId, int> completedRepeatableTasks { get; set; }

        [MetaMember(64, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public bool DidClaimFreeGems { get; set; }

        [MetaMember(65, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<HotspotId, MetaTime> visibleHotspotsWithTimestamps { get; set; }

        [MetaMember(66, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public bool DidFlashSellTutorialFinished { get; set; }

        [IgnoreDataMember]
        public MetaTime LastModificationTime { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(67, (MetaMemberFlags)0)]
        private HashSet<PetId> Pets { get; set; }

        [MetaMember(68, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private PetId ActivePet { get; set; }

        public Dictionary<ItemDefinition, int> DebugGeneratedDynamicTasksPool;
        [MetaMember(69, (MetaMemberFlags)0)]
        public Dictionary<EventTaskId, List<PlayerRequirement>> DynamicTaskRequirements { get; set; }

        [MetaMember(70, (MetaMemberFlags)0)]
        public Dictionary<EventTaskId, List<PlayerReward>> DynamicTaskRewards { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(71, (MetaMemberFlags)0)]
        public Dictionary<SideBoardEventId, SideBoardEventProgressState> SideBoardEventProgressStateBySideBoardEventId { get; set; }

        [MetaMember(72, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public Dictionary<MergeBoardId, long> AnalyticsFakeZeroEnergySaldoByMergeBoardId { get; set; }

        [MetaMember(73, (MetaMemberFlags)0)]
        public Dictionary<EventTaskId, List<DebugItemData>> DynamicTasksPayload { get; set; }

        [MetaMember(74, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        private Dictionary<HotspotId, CardStack> visibleCardStacks { get; set; }

        [MetaMember(75, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public AdsData adRewardToClaim { get; set; }
    }
}
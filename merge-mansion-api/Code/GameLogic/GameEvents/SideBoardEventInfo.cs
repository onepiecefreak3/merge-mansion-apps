using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using System.Reflection;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;
using System.Collections.Generic;
using GameLogic.Story;
using GameLogic.Player.Requirements;
using Metaplay.Core.Offers;
using GameLogic.Decorations;
using GameLogic.Config;
using System.Runtime.Serialization;
using GameLogic.Player.Rewards;
using Merge;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableConfigData("SideBoardEvent", false, true)]
    [MetaSerializable]
    [DefaultMember("Item")]
    public class SideBoardEventInfo : IMetaActivableConfigData<SideBoardEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<SideBoardEventId>, IGameConfigKey<SideBoardEventId>, IMetaActivableInfo<SideBoardEventId>, IBoardEventInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SideBoardEventId SideBoardEventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaRef<BoardInfo> BoardRef { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> PortalItemRef { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> FallbackLevelRefs { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public MetaRef<EventCurrencyInfo> EventCurrencyInfo { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        private MetaRef<DecorationInfo> ActiveDecorationRef { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public List<int> ProgressionPopupHeaderImageLevels { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public MetaRef<EventTaskInfo> EventInitTask { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public List<MetaRef<EventTaskInfo>> EventTasks { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public int LimitResourceItem { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ResourceItemRef { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ResourceItemSpawnerRef { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> EmptySinkResourceItemRef { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> ItemRefsDisplayingResourceItemCountOnBoard { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> ItemRefsDisplayingResourceItemCountOnItemInfoArea { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public string IsResourceItemAtMaxItemInfoAreaLocId { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public string IsResourceItemAtMaxItemInfoAreaPortalLocId { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public List<EventTaskLocEntry> EndPopupOptions { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public ExtendableEventParams ExtendableEventParams { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        public MetaDuration? ShowTimeInCalendarPopupAfterFinish { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ResourceItemCollectableRef { get; set; }
        public bool HasCustomCurrency { get; }
        public SideBoardEventId ConfigKey => SideBoardEventId;
        public SideBoardEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        [IgnoreDataMember]
        public BoardInfo Board { get; }

        [IgnoreDataMember]
        public ItemDefinition PortalItem { get; }

        [IgnoreDataMember]
        public ItemDefinition ResourceItemCollectable { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> Levels { get; }

        [IgnoreDataMember]
        public int SecondaryEnergyAttachmentChance { get; }
        public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; }
        public MetaDuration ExtensionPurchaseSafetyMargin { get; }
        public List<PlayerReward> ExtensionRewards { get; }
        public OfferPlacementId BoardShopFlashPlacementId { get; }
        public OfferPlacementId BoardShopEventCurrencyPlacementId { get; }

        [IgnoreDataMember]
        IStringId Code.GameLogic.GameEvents.IBoardEventInfo.BoardEventId { get; }

        [IgnoreDataMember]
        MergeBoardId Code.GameLogic.GameEvents.IBoardEventInfo.MergeBoardId { get; }

        [IgnoreDataMember]
        public DecorationInfo ActiveDecoration { get; }

        [IgnoreDataMember]
        public int AuxEnergyAttachmentChance { get; }

        [IgnoreDataMember]
        public EventTaskInfo Item { get; }

        public SideBoardEventInfo()
        {
        }

        public SideBoardEventInfo(SideBoardEventId sideBoardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, List<MetaRef<EventLevelInfo>> levelRefs, Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> fallbackLevelRefs, StoryDefinitionId enterBoardDialogue, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, DecorationId activeDecoration, List<int> progressionPopupHeaderImageLevels, string initTask, List<MetaRef<EventTaskInfo>> eventTasks, ExtendableEventParams extendableEventParams, int limitResourceItem, MetaRef<ItemDefinition> resourceItemRef, MetaRef<ItemDefinition> resourceItemCollectableRef, MetaRef<ItemDefinition> resourceItemSpawnerRef, MetaRef<ItemDefinition> emptySinkResourceItemRef, List<MetaRef<ItemDefinition>> itemRefsDisplayingResourceItemCountOnBoard, List<MetaRef<ItemDefinition>> itemRefsDisplayingResourceItemCountOnItemInfoArea, string isResourceItemAtMaxItemInfoAreaLocId, string isResourceItemAtMaxItemInfoAreaPortalLocId, List<EventTaskLocEntry> endPopupOptions, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaDuration? showTimeInCalendarPopupAfterFinish)
        {
        }
    }
}
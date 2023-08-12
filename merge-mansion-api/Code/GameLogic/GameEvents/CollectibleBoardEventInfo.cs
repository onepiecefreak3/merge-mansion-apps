using System.Collections.Generic;
using GameLogic.Player.Items;
using GameLogic.Player.Requirements;
using GameLogic.Story;
using Metaplay.Core;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using GameLogic.Decorations;
using System;
using GameLogic.Config;
using GameLogic.Player.Rewards;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class CollectibleBoardEventInfo : IMetaActivableConfigData<CollectibleBoardEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<CollectibleBoardEventId>, IMetaActivableInfo<CollectibleBoardEventId>, IBoardEventInfo
    {
        [MetaMember(1, 0)]
        public CollectibleBoardEventId CollectibleBoardEventId { get; set; }

        [MetaMember(2, 0)]
        public string NameLocId { get; set; }

        [MetaMember(3, 0)]
        public string DisplayName { get; set; }

        [MetaMember(4, 0)]
        public string Description { get; set; }

        [MetaMember(5, 0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(6, 0)]
        public MetaRef<BoardInfo> BoardRef { get; set; }

        [MetaMember(7, 0)]
        public MetaRef<ItemDefinition> PortalItemRef { get; set; }

        [MetaMember(8, 0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }

        [MetaMember(9, 0)]
        public List<MetaRef<EventLevelInfo>> RecurringLevelRefs { get; set; }

        [MetaMember(10, 0)]
        public Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> FallbackLevelRefs { get; set; }

        [MetaMember(11, 0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }

        [MetaMember(12, 0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(13, 0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(14, 0)]
        public StoryDefinitionId EndDialogue { get; set; }
        public CollectibleBoardEventId ConfigKey => CollectibleBoardEventId;

        [MetaMember(15, (MetaMemberFlags)0)]
        private MetaRef<DecorationInfo> ActiveDecorationRef { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public List<int> ProgressionPopupHeaderImageLevels { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public MetaRef<EventTaskInfo> EventInitTask { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public List<MetaRef<EventTaskInfo>> EventTasks { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        private MetaRef<StoryElementInfo> StartDialogueRef { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public ExtendableEventParams ExtendableEventParams { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public MetaDuration ExtensionPurchaseSafetyMargin { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public List<PlayerReward> ExtensionRewards { get; set; }
        public CollectibleBoardEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        [IgnoreDataMember]
        public BoardInfo Board { get; }

        [IgnoreDataMember]
        public ItemDefinition PortalItem { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> Levels { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> RecurringLevels { get; }
        public OfferPlacementId BoardShopFlashPlacementId { get; }

        [IgnoreDataMember]
        IStringId Code.GameLogic.GameEvents.IBoardEventInfo.Id { get; }

        [IgnoreDataMember]
        public DecorationInfo ActiveDecoration { get; }

        [IgnoreDataMember]
        public StoryElementInfo StartDialogue { get; }

        [IgnoreDataMember]
        public EventTaskInfo Item { get; }

        public CollectibleBoardEventInfo()
        {
        }

        public CollectibleBoardEventInfo(CollectibleBoardEventId collectibleBoardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, List<MetaRef<EventLevelInfo>> levelRefs, List<MetaRef<EventLevelInfo>> recurringLevelRefs, Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> fallbackLevelRefs, StoryDefinitionId enterBoardDialogue, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, StoryDefinitionId endDialogue, DecorationId activeDecoration, List<int> progressionPopupHeaderImageLevels, string initTask, List<MetaRef<EventTaskInfo>> eventTasks, StoryDefinitionId startDialogue, ExtendableEventParams extendableEventParams, MetaRef<InAppProductInfo> extensionInAppProduct, MetaDuration extensionPurchaseSafetyMargin, IEnumerable<PlayerReward> extensionRewards)
        {
        }

        [MetaMember(24, (MetaMemberFlags)0)]
        public int SecondaryEnergyAttachmentChance { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public PlayerRequirement PreviewRequirement { get; set; }

        public CollectibleBoardEventInfo(CollectibleBoardEventId collectibleBoardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, List<MetaRef<EventLevelInfo>> levelRefs, List<MetaRef<EventLevelInfo>> recurringLevelRefs, Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> fallbackLevelRefs, StoryDefinitionId enterBoardDialogue, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, StoryDefinitionId endDialogue, DecorationId activeDecoration, List<int> progressionPopupHeaderImageLevels, string initTask, List<MetaRef<EventTaskInfo>> eventTasks, StoryDefinitionId startDialogue, ExtendableEventParams extendableEventParams, MetaRef<InAppProductInfo> extensionInAppProduct, MetaDuration extensionPurchaseSafetyMargin, IEnumerable<PlayerReward> extensionRewards, int secondaryEnergyAttachmentChance, PlayerRequirement previewRequirement)
        {
        }
    }
}
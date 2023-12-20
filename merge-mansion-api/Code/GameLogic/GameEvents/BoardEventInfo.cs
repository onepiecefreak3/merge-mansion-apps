using System.Collections.Generic;
using GameLogic.Config;
using GameLogic.ConfigPrefabs;
using GameLogic.Player.Director.Config;
using GameLogic.Story;
using Metaplay.Core;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Code.GameLogic.Config;
using System;
using GameLogic.Player.Requirements;
using GameLogic.Decorations;
using GameLogic.Player.Rewards;
using System.Runtime.Serialization;
using GameLogic;
using System.Reflection;
using Merge;
using Metaplay.Core.Math;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [DefaultMember("Item")]
    [MetaActivableConfigData("BoardEvent", false)]
    [MetaBlockedMembers(new int[] { 10, 11, 13, 14, 16 })]
    public class BoardEventInfo : IMetaActivableConfigData<EventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<EventId>, IGameConfigKey<EventId>, IMetaActivableInfo<EventId>, IValidatable, IBoardEventInfo, IEventGroupInfo
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }

        [MetaMember(2, 0)]
        public string DisplayName { get; set; }

        [MetaMember(3, 0)]
        public string Description { get; set; }

        [MetaMember(4, 0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(5, 0)]
        public MetaRef<EventCurrencyInfo> EventCurrencyInfo { get; set; }

        [MetaMember(6, 0)]
        public MetaRef<BoardInfo> BoardInfo { get; set; }

        [MetaMember(7, 0)]
        public MetaRef<EventTaskInfo> EventInitTask { get; set; }

        [MetaMember(8, 0)]
        public List<MetaRef<EventTaskInfo>> EventTasks { get; set; }

        [MetaMember(9, 0)]
        public MetaRef<EventLevels> Levels { get; set; }

        [MetaMember(12, 0)]
        public ItemTypeConstant? PortalItem { get; set; }

        [MetaMember(15, 0)]
        public string NameLocalizationId { get; set; }

        [MetaMember(17, 0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(18, 0)]
        public ExtendableEventParams ExtendableEventParams { get; set; }

        [MetaMember(19, 0)]
        public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }

        [MetaMember(20, 0)]
        public MetaDuration ExtensionPurchaseSafetyMargin { get; set; }

        [MetaMember(21, 0)]
        public ConfigPrefabId InfoPopupId { get; set; }

        [MetaMember(22, 0)]
        public ConfigPrefabId TaskProgressionId { get; set; }

        [MetaMember(23, 0)]
        public ConfigPrefabId TaskGoalItemId { get; set; }

        [MetaMember(24, 0)]
        public MetaRef<ShopEventInfo> HintedShopEvent { get; set; }

        [MetaMember(25, 0)]
        public StoryDefinitionId StartEventDialogue { get; set; }

        [MetaMember(26, 0)]
        public ConfigPrefabId StartPopupId { get; set; }

        [MetaMember(27, 0)]
        public ConfigPrefabId TeasePopupId { get; set; }

        [MetaMember(28, 0)]
        public ConfigPrefabId IntroPopupId { get; set; }

        [MetaMember(29, 0)]
        public ConfigPrefabId ExtendPopupId { get; set; }

        [MetaMember(30, 0)]
        public ConfigPrefabId EndPopupId { get; set; }

        [MetaMember(31, 0)]
        public ConfigPrefabId HudButtonId { get; set; }

        [MetaMember(32, 0)]
        public ConfigPrefabId RewardInfoPopupId { get; set; }

        [MetaMember(35, 0)]
        public bool VisualiseEventPoints { get; set; }

        [MetaMember(36, 0)]
        public ConfigPrefabId TaskItemCheckmarkId { get; set; }

        [MetaMember(37, 0)]
        private List<IDirectorAction> StartActions { get; set; }

        [MetaMember(38, 0)]
        private List<IDirectorAction> EndActions { get; set; }
        public EventId ConfigKey => EventId;
        public IEnumerable<IDirectorAction> OnStart => StartActions;
        public IEnumerable<IDirectorAction> OnEnd => EndActions;

        [MetaMember(39, (MetaMemberFlags)0)]
        public string BoardTransitionSfxOverride { get; set; }

        [MetaMember(40, (MetaMemberFlags)0)]
        public PlayerRequirement PreviewRequirement { get; set; }

        [MetaMember(41, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(42, (MetaMemberFlags)0)]
        private MetaRef<DecorationInfo> ActiveDecorationRef { get; set; }

        [MetaMember(43, (MetaMemberFlags)0)]
        public bool GivePortalItemWithoutTask { get; set; }

        [MetaMember(44, (MetaMemberFlags)0)]
        public List<PlayerReward> ExtensionRewards { get; set; }
        public EventId ActivableId { get; }
        public string DisplayShortInfo { get; }
        public bool HasCustomCurrency { get; }
        public bool HasCustomBoard { get; }
        public bool HasInfoPopup { get; }
        public bool HasStartPopup { get; }
        public bool HasTeasePopup { get; }
        public bool HasIntroPopup { get; }
        public bool HasHudButton { get; }
        public bool HasEndPopup { get; }
        public bool HasTaskItemCheckmark { get; }
        public OfferPlacementId BoardShopFlashPlacementId { get; }

        [IgnoreDataMember]
        public EventTaskInfo Item { get; }

        [IgnoreDataMember]
        IStringId Code.GameLogic.GameEvents.IBoardEventInfo.Id { get; }

        [IgnoreDataMember]
        StoryDefinitionId Code.GameLogic.GameEvents.IBoardEventInfo.EnterBoardDialogue { get; }

        [IgnoreDataMember]
        public DecorationInfo ActiveDecoration { get; }

        public BoardEventInfo()
        {
        }

        public BoardEventInfo(EventId eventId, string displayName, string description, MetaActivableParams activableParams, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaRef<BoardInfo> boardInfo, MetaRef<EventTaskInfo> eventInitTask, List<MetaRef<EventTaskInfo>> eventTasks, MetaRef<EventLevels> eventLevels, int? portalItem, string nameLocId, OfferPlacementId offerPlacementId, ExtendableEventParams extendableEventParams, MetaDuration extensionPurchaseSafetyMargin, MetaRef<InAppProductInfo> extensionInAppProduct, ConfigPrefabId infoPopupId, ConfigPrefabId taskProgressionId, ConfigPrefabId taskGoalItemId, StoryDefinitionId startEventDialogue, MetaRef<ShopEventInfo> hintedShopEvents, ConfigPrefabId startPopupId, ConfigPrefabId teasePopupId, ConfigPrefabId introPopupId, ConfigPrefabId extendPopupId, ConfigPrefabId endPopupId, ConfigPrefabId hudButtonId, ConfigPrefabId rewardInfoPopupId, ConfigPrefabId rewardClaimPopupId, ConfigPrefabId rewardChestPopupId, bool visualiseEventPoints, ConfigPrefabId taskItemCheckmarkId, List<IDirectorAction> startActions, List<IDirectorAction> endActions, string boardTransitionSfxOverride, PlayerRequirement previewRequirement, PlayerRequirement unlockRequirement, DecorationId activeDecoration, bool givePortalItemWithoutTask, IEnumerable<PlayerReward> extensionRewards)
        {
        }

        public BoardEventInfo(EventId eventId, string displayName, string description, MetaActivableParams activableParams, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaRef<BoardInfo> boardInfo, MetaRef<EventTaskInfo> eventInitTask, List<MetaRef<EventTaskInfo>> eventTasks, MetaRef<EventLevels> eventLevels, int? portalItem, string nameLocId, OfferPlacementId offerPlacementId, ExtendableEventParams extendableEventParams, MetaDuration extensionPurchaseSafetyMargin, MetaRef<InAppProductInfo> extensionInAppProduct, ConfigPrefabId infoPopupId, ConfigPrefabId taskProgressionId, ConfigPrefabId taskGoalItemId, StoryDefinitionId startEventDialogue, MetaRef<ShopEventInfo> hintedShopEvents, ConfigPrefabId startPopupId, ConfigPrefabId teasePopupId, ConfigPrefabId introPopupId, ConfigPrefabId extendPopupId, ConfigPrefabId endPopupId, ConfigPrefabId hudButtonId, ConfigPrefabId rewardInfoPopupId, ConfigPrefabId rewardClaimPopupId, ConfigPrefabId rewardChestPopupId, bool visualiseEventPoints, ConfigPrefabId taskItemCheckmarkId, List<IDirectorAction> startActions, List<IDirectorAction> endActions, string boardTransitionSfxOverride, PlayerRequirement previewRequirement, PlayerRequirement unlockRequirement, DecorationId activeDecoration, bool givePortalItemWithoutTask, IEnumerable<PlayerReward> extensionRewards, int secondaryEnergyAttachmentChance)
        {
        }

        [MetaMember(46, (MetaMemberFlags)0)]
        public string PrefabsId { get; set; }

        [IgnoreDataMember]
        MergeBoardId Code.GameLogic.GameEvents.IBoardEventInfo.MergeBoardId { get; }

        [IgnoreDataMember]
        public F32? BubbleBonusDivisor { get; }

        [IgnoreDataMember]
        public EnergyType? AuxEnergyType { get; }

        [IgnoreDataMember]
        public int AuxEnergyAttachmentChance { get; }

        public BoardEventInfo(EventId eventId, string displayName, string description, MetaActivableParams activableParams, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaRef<BoardInfo> boardInfo, MetaRef<EventTaskInfo> eventInitTask, List<MetaRef<EventTaskInfo>> eventTasks, MetaRef<EventLevels> eventLevels, int? portalItem, string nameLocId, OfferPlacementId offerPlacementId, ExtendableEventParams extendableEventParams, MetaDuration extensionPurchaseSafetyMargin, MetaRef<InAppProductInfo> extensionInAppProduct, ConfigPrefabId infoPopupId, ConfigPrefabId taskProgressionId, ConfigPrefabId taskGoalItemId, StoryDefinitionId startEventDialogue, MetaRef<ShopEventInfo> hintedShopEvents, ConfigPrefabId startPopupId, ConfigPrefabId teasePopupId, ConfigPrefabId introPopupId, ConfigPrefabId extendPopupId, ConfigPrefabId endPopupId, ConfigPrefabId hudButtonId, ConfigPrefabId rewardInfoPopupId, ConfigPrefabId rewardClaimPopupId, ConfigPrefabId rewardChestPopupId, bool visualiseEventPoints, ConfigPrefabId taskItemCheckmarkId, List<IDirectorAction> startActions, List<IDirectorAction> endActions, string boardTransitionSfxOverride, PlayerRequirement previewRequirement, PlayerRequirement unlockRequirement, DecorationId activeDecoration, bool givePortalItemWithoutTask, IEnumerable<PlayerReward> extensionRewards, string prefabsId)
        {
        }

        [MetaMember(47, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        public BoardEventInfo(EventId eventId, string displayName, string description, MetaActivableParams activableParams, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaRef<BoardInfo> boardInfo, MetaRef<EventTaskInfo> eventInitTask, List<MetaRef<EventTaskInfo>> eventTasks, MetaRef<EventLevels> eventLevels, int? portalItem, string nameLocId, OfferPlacementId offerPlacementId, ExtendableEventParams extendableEventParams, MetaDuration extensionPurchaseSafetyMargin, MetaRef<InAppProductInfo> extensionInAppProduct, ConfigPrefabId infoPopupId, ConfigPrefabId taskProgressionId, ConfigPrefabId taskGoalItemId, StoryDefinitionId startEventDialogue, MetaRef<ShopEventInfo> hintedShopEvents, ConfigPrefabId startPopupId, ConfigPrefabId teasePopupId, ConfigPrefabId introPopupId, ConfigPrefabId extendPopupId, ConfigPrefabId endPopupId, ConfigPrefabId hudButtonId, ConfigPrefabId rewardInfoPopupId, ConfigPrefabId rewardClaimPopupId, ConfigPrefabId rewardChestPopupId, bool visualiseEventPoints, ConfigPrefabId taskItemCheckmarkId, List<IDirectorAction> startActions, List<IDirectorAction> endActions, string boardTransitionSfxOverride, PlayerRequirement previewRequirement, PlayerRequirement unlockRequirement, DecorationId activeDecoration, bool givePortalItemWithoutTask, IEnumerable<PlayerReward> extensionRewards, string prefabsId, EventGroupId groupId)
        {
        }

        [MetaMember(48, (MetaMemberFlags)0)]
        public bool HasDynamicTasks { get; set; }

        public BoardEventInfo(EventId eventId, string displayName, string description, MetaActivableParams activableParams, MetaRef<EventCurrencyInfo> eventCurrencyInfo, MetaRef<BoardInfo> boardInfo, MetaRef<EventTaskInfo> eventInitTask, List<MetaRef<EventTaskInfo>> eventTasks, MetaRef<EventLevels> eventLevels, int? portalItem, string nameLocId, OfferPlacementId offerPlacementId, ExtendableEventParams extendableEventParams, MetaDuration extensionPurchaseSafetyMargin, MetaRef<InAppProductInfo> extensionInAppProduct, ConfigPrefabId infoPopupId, ConfigPrefabId taskProgressionId, ConfigPrefabId taskGoalItemId, StoryDefinitionId startEventDialogue, MetaRef<ShopEventInfo> hintedShopEvents, ConfigPrefabId startPopupId, ConfigPrefabId teasePopupId, ConfigPrefabId introPopupId, ConfigPrefabId extendPopupId, ConfigPrefabId endPopupId, ConfigPrefabId hudButtonId, ConfigPrefabId rewardInfoPopupId, bool visualiseEventPoints, ConfigPrefabId taskItemCheckmarkId, List<IDirectorAction> startActions, List<IDirectorAction> endActions, string boardTransitionSfxOverride, PlayerRequirement previewRequirement, PlayerRequirement unlockRequirement, DecorationId activeDecoration, bool givePortalItemWithoutTask, IEnumerable<PlayerReward> extensionRewards, string prefabsId, EventGroupId groupId, bool hasDynamicTasks)
        {
        }
    }
}
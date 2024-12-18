using System.Collections.Generic;
using GameLogic.Config;
using GameLogic.ConfigPrefabs;
using GameLogic.Story;
using Metaplay.Core;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using System;
using GameLogic.Player.Requirements;
using System.Runtime.Serialization;
using GameLogic;
using Metaplay.Core.Math;
using Code.GameLogic.Config;
using GameLogic.Cutscenes;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [MetaActivableConfigData("ProgressionEvent", false, true)]
    [MetaBlockedMembers(new int[] { 5, 6 })]
    [MetaBlockedMembers(new int[] { 7, 8 })]
    [MetaBlockedMembers(new int[] { 14, 15, 16, 17, 18, 30 })]
    public class ProgressionEventInfo : IMetaActivableConfigData<ProgressionEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<ProgressionEventId>, IHasGameConfigKey<ProgressionEventId>, IMetaActivableInfo<ProgressionEventId>, IValidatable, IBubbleBonusEvent, IEventSharedInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId ProgressionEventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> FreeEventLevels { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<int> ChancesToSpawnEventItemPerLevel { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int EventItem { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfo> PremiumIAP { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public int PremiumIAPOfferMinLevel { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public StoryDefinitionId IntroDialogue { get; set; }
        public ProgressionEventId ConfigKey => ProgressionEventId;

        [MetaMember(20, (MetaMemberFlags)0)]
        private List<MetaRef<ProgressionEventPerkInfo>> PremiumIAPPerkRefs { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        private List<MetaRef<EventLevelInfo>> FreeEventLevelRefs { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        private List<MetaRef<EventLevelInfo>> PremiumEventLevelRefs { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        private List<MetaRef<EventLevelInfo>> RecurringFreeEventLevelRefs { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        private List<MetaRef<EventLevelInfo>> RecurringPremiumEventLevelRefs { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public int RecurringLevelPointsIncrement { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        public bool HasZeroLevel { get; set; }

        [MetaMember(31, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        public StoryDefinitionId EndDialogue { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        private List<MetaRef<StoryElementInfo>> LevelRewardClaimedStoryRefs { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        private List<MetaRef<EventLevelInfo>> StoryTriggeringLevelRefs { get; set; }
        public ProgressionEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        [IgnoreDataMember]
        public IEnumerable<StoryElementInfo> LevelRewardClaimedStories { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> StoryTriggeringLevels { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> RecurringFreeEventLevels { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> RecurringPremiumEventLevels { get; }

        [IgnoreDataMember]
        public int DefaultMaxLevelNumber { get; }

        [IgnoreDataMember]
        public int MinLevelNumber { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> AllEventLevels { get; }

        public ProgressionEventInfo()
        {
        }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement)
        {
        }

        [MetaMember(32, (MetaMemberFlags)0)]
        public F32? BubbleBonusDivisor { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        private List<MetaRef<ProgressionEventStreakRewards>> PremiumIAPStreakRewardRefs { get; set; }

        [IgnoreDataMember]
        private IEnumerable<ProgressionEventStreakRewards> PremiumIAPStreakRewards { get; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor)
        {
        }

        [MetaMember(34, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId)
        {
        }

        [MetaMember(35, (MetaMemberFlags)0)]
        private List<EventLevelId> TeasedEventLevelIds { get; set; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelId> TeasedEventLevels { get; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId, List<EventLevelId> teasedEventLevelIds)
        {
        }

        [MetaMember(36, (MetaMemberFlags)0)]
        public CutsceneId IntroCutscene { get; set; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId, List<EventLevelId> teasedEventLevelIds, CutsceneId introCutscene)
        {
        }

        [IgnoreDataMember]
        public List<BubbleBonusInfo> SecondaryBoardBubbleBonus { get; }

        [MetaMember(37, (MetaMemberFlags)0)]
        public string StartPopupDescId { get; set; }

        [MetaMember(38, (MetaMemberFlags)0)]
        public string EndPopupNoRewardsDescId { get; set; }

        [MetaMember(39, (MetaMemberFlags)0)]
        public string EventPrefabsId { get; set; }

        [MetaMember(40, (MetaMemberFlags)0)]
        public string StartHeaderBackgroundId { get; set; }

        [MetaMember(41, (MetaMemberFlags)0)]
        public string EndHeaderBackgroundId { get; set; }

        [MetaMember(42, (MetaMemberFlags)0)]
        public string MainHubBadgeIconId { get; set; }

        [MetaMember(43, (MetaMemberFlags)0)]
        public string TodoItemHeaderBackgroundId { get; set; }

        [MetaMember(44, (MetaMemberFlags)0)]
        public string ProgressionPopupHeaderBackgroundId { get; set; }

        [MetaMember(45, (MetaMemberFlags)0)]
        public string EventRewardTagId { get; set; }

        [MetaMember(46, (MetaMemberFlags)0)]
        public string UiCharacterItemId { get; set; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string startPopupDescId, string endPopupNoRewardsDescId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId, List<EventLevelId> teasedEventLevelIds, CutsceneId introCutscene, string eventPrefabsId, string startHeaderBackgroundId, string endHeaderBackgroundId, string mainHubBadgeIconId, string todoItemHeaderBackgroundId, string progressionPopupHeaderBackgroundId, string eventRewardTagId, string uiCharacterItemId)
        {
        }

        [MetaMember(48, (MetaMemberFlags)0)]
        public string ShopBundleHeaderId { get; set; }

        [MetaMember(47, (MetaMemberFlags)0)]
        public MetaRef<ProgressionEventV2Info> V2Info { get; set; }

        [MetaMember(49, (MetaMemberFlags)0)]
        public List<int> PurchasePopupTriggeringLevels { get; set; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> Track1EventLevels { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> Track2EventLevels { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> BonusEventLevels { get; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string startPopupDescId, string endPopupNoRewardsDescId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId, List<EventLevelId> teasedEventLevelIds, CutsceneId introCutscene, string eventPrefabsId, string startHeaderBackgroundId, string endHeaderBackgroundId, string mainHubBadgeIconId, string todoItemHeaderBackgroundId, string progressionPopupHeaderBackgroundId, string eventRewardTagId, string uiCharacterItemId, string shopBundleHeaderId, List<int> purchasePopupTriggeringLevels, ProgressionEventV2Id v2Id)
        {
        }

        [MetaMember(50, (MetaMemberFlags)0)]
        public int Priority { get; set; }
        public string SharedEventId { get; }

        public ProgressionEventInfo(ProgressionEventId progressionEventId, string nameLocId, string startPopupDescId, string endPopupNoRewardsDescId, string displayName, string description, MetaActivableParams activableParams, List<int> chancesToSpawnEventPerItemLevel, int eventItem, MetaRef<InAppProductInfo> premiumIap, int premiumIapOfferMinLevel, List<MetaRef<ProgressionEventPerkInfo>> premiumIapPerks, List<MetaRef<ProgressionEventStreakRewards>> premiumIAPStreakRewards, List<MetaRef<EventLevelInfo>> freeEventLevels, List<MetaRef<EventLevelInfo>> premiumEventLevels, List<MetaRef<EventLevelInfo>> recurringFreeEventLevels, List<MetaRef<EventLevelInfo>> recurringPremiumEventLevels, int recurringLevelPointsIncrement, bool hasZeroLevel, StoryDefinitionId introDialogue, StoryDefinitionId endDialogue, List<MetaRef<StoryElementInfo>> levelRewardClaimedStories, List<MetaRef<EventLevelInfo>> storyTriggeringLevels, PlayerRequirement unlockRequirement, F32? bubbleBonusDivisor, EventGroupId groupId, List<EventLevelId> teasedEventLevelIds, CutsceneId introCutscene, string eventPrefabsId, string startHeaderBackgroundId, string endHeaderBackgroundId, string mainHubBadgeIconId, string todoItemHeaderBackgroundId, string progressionPopupHeaderBackgroundId, string eventRewardTagId, string uiCharacterItemId, string shopBundleHeaderId, List<int> purchasePopupTriggeringLevels, ProgressionEventV2Id v2Id, int priority)
        {
        }
    }
}
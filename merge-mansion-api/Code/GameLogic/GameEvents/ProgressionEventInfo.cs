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
    [MetaBlockedMembers(new int[] { 7, 8 })]
    [MetaBlockedMembers(new int[] { 14, 15, 16, 17, 18, 30 })]
    [MetaBlockedMembers(new int[] { 5, 6 })]
    [MetaActivableConfigData("ProgressionEvent", false)]
    public class ProgressionEventInfo : IMetaActivableConfigData<ProgressionEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<ProgressionEventId>, IHasGameConfigKey<ProgressionEventId>, IMetaActivableInfo<ProgressionEventId>, IValidatable, IBubbleBonusEvent, IEventGroupInfo
    {
        [MetaMember(1)]
        public ProgressionEventId ProgressionEventId { get; set; }

        [MetaMember(2)]
        public string NameLocId { get; set; }

        [MetaMember(3)]
        public string DisplayName { get; set; }

        [MetaMember(4)]
        public string Description { get; set; }

        [MetaMember(5)]
        public List<EventLevelId> FreeEventLevels { get; set; }

        [MetaMember(6)]
        public List<EventLevelId> PremiumEventLevels { get; set; }

        [MetaMember(9)]
        public List<int> ChancesToSpawnEventItemPerLevel { get; set; }

        [MetaMember(10)]
        public ItemTypeConstant EventItem { get; set; }

        [MetaMember(11)]
        public MetaRef<InAppProductInfo> PremiumIAP { get; set; }

        [MetaMember(12, 0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(13, 0)]
        public int PremiumIAPOfferMinLevel { get; set; }

        [MetaMember(19, 0)]
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
        public IEnumerable<ProgressionEventPerkInfo> PremiumIAPPerks { get; }

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
    }
}
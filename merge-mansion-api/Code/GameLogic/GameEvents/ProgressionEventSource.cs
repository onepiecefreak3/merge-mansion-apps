using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using GameLogic.Story;
using GameLogic.Cutscenes;
using Metaplay.Core.Math;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class ProgressionEventSource : IConfigItemSource<ProgressionEventInfo, ProgressionEventId>, IGameConfigSourceItem<ProgressionEventId, ProgressionEventInfo>, IHasGameConfigKey<ProgressionEventId>
    {
        private ProgressionEventId EventId { get; set; }
        private string NameLocId { get; set; }
        private string StartPopupDescId { get; set; }
        private string EndPopupNoRewardsDescId { get; set; }
        private string EventPrefabsId { get; set; }
        private string StartHeaderBackgroundId { get; set; }
        private string EndHeaderBackgroundId { get; set; }
        private string MainHubBadgeIconId { get; set; }
        private string TodoItemHeaderBackgroundId { get; set; }
        private string ProgressionPopupHeaderBackgroundId { get; set; }
        private string EventRewardTagId { get; set; }
        private string UiCharacterItemId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string ChanceToSpawnEventItemPerLevel { get; set; }
        private string EventItem { get; set; }
        private int PremiumIAPOfferMinLevel { get; set; }
        private List<MetaRef<ProgressionEventStreakRewards>> PremiumIAPStreakRewards { get; set; }
        private List<MetaRef<EventLevelInfo>> FreeEventLevels { get; set; }
        private bool HasZeroLevel { get; set; }
        private StoryDefinitionId IntroDialogue { get; set; }
        private StoryDefinitionId EndDialogue { get; set; }
        private List<MetaRef<StoryElementInfo>> LevelRewardClaimedStories { get; set; }
        private List<MetaRef<EventLevelInfo>> StoryTriggeringLevels { get; set; }
        private CutsceneId IntroCutscene { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private EventGroupId GroupId { get; set; }
        private F32? BubbleBonusDivisor { get; set; }
        private List<EventLevelId> TeasedEventLevelIds { get; set; }
        public ProgressionEventId ConfigKey { get; }

        public ProgressionEventSource()
        {
        }

        private string ShopBundleHeaderId { get; set; }
        private List<int> PurchasePopupTriggeringLevels { get; set; }
        private int Priority { get; set; }
        private MetaRef<InAppProductInfo> Track1IAP { get; set; }
        private MetaRef<InAppProductInfo> Track2IAP { get; set; }
        private MetaRef<InAppProductInfo> UpgradeIAP { get; set; }
        private List<MetaRef<EventLevelInfo>> Track1EventLevels { get; set; }
        private List<MetaRef<EventLevelInfo>> Track2EventLevels { get; set; }
        private List<MetaRef<EventLevelInfo>> BonusLevels { get; set; }
        private bool IsBonusRewardSecret { get; set; }
        private List<MetaRef<ProgressionEventPerkInfo>> Track1IAPPerks { get; set; }
        private List<MetaRef<ProgressionEventPerkInfo>> Track2IAPPerks { get; set; }
        private string PriceValueLocIdTrack1 { get; set; }
        private string PriceValueLocIdTrack2 { get; set; }
    }
}
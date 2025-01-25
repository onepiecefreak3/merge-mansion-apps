using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using GameLogic.Player.Rewards;
using GameLogic.Story;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    public class ShortLeaderboardEventSource : IConfigItemSource<ShortLeaderboardEventInfo, ShortLeaderboardEventId>, IGameConfigSourceItem<ShortLeaderboardEventId, ShortLeaderboardEventInfo>, IHasGameConfigKey<ShortLeaderboardEventId>
    {
        public ShortLeaderboardEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private EventGroupId GroupId { get; set; }
        private int Priority { get; set; }
        private string NameLocalizationId { get; set; }
        private List<MetaRef<ShortLeaderboardEventStageInfo>> Stages { get; set; }
        private MetaRef<RewardUpgradableInfo> FinalReward { get; set; }
        private StoryDefinitionId IntroDialogue { get; set; }
        private StoryDefinitionId EndDialogue { get; set; }
        private bool DisableBubbleBonus { get; set; }
        private F32? BubbleBonusDivisor { get; set; }
        private List<int> SecondaryBoardDivisorEnergyType { get; set; }
        private List<F32> SecondaryBoardBubbleDivisorOverride { get; set; }
        private List<bool> SecondaryBoardBubbleDivisorEnabled { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private string PreviewRequirementType { get; set; }
        private string PreviewRequirementId { get; set; }
        private string PreviewRequirementAmount { get; set; }
        private string PreviewRequirementAux0 { get; set; }

        public ShortLeaderboardEventSource()
        {
        }
    }
}
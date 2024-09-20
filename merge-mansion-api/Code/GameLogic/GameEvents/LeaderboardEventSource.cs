using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Metaplay.Core.Offers;
using GameLogic.Story;
using GameLogic.Player;
using Metaplay.Core.Math;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class LeaderboardEventSource : IConfigItemSource<LeaderboardEventInfo, LeaderboardEventId>, IGameConfigSourceItem<LeaderboardEventId, LeaderboardEventInfo>, IHasGameConfigKey<LeaderboardEventId>
    {
        private LeaderboardEventId EventId { get; set; }
        private string NameLocId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private MetaRef<BoardInfo> Board { get; set; }
        private string PortalItem { get; set; }
        private OfferPlacementId BoardShopPlacementId { get; set; }
        private List<MetaRef<EventLevelInfo>> Levels { get; set; }
        private StoryDefinitionId EnterBoardDialogue { get; set; }
        private StoryDefinitionId EndDialogue { get; set; }
        private List<MetaRef<EventLevelInfo>> RankingRewardLevels { get; set; }
        private EnergyType? AuxEnergyType { get; set; }
        private MetaDuration? AuxEnergyUnitRestoreDuration { get; set; }
        private int AuxEnergyAttachmentChance { get; set; }
        private EventGroupId GroupId { get; set; }
        private bool DisableBubbleBonus { get; set; }
        private F32? BubbleBonusDivisor { get; set; }
        private List<int> SecondaryBoardDivisorEnergyType { get; set; }
        private List<F32> SecondaryBoardBubbleDivisorOverride { get; set; }
        private List<bool> SecondaryBoardBubbleDivisorEnabled { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        public LeaderboardEventId ConfigKey { get; }

        public LeaderboardEventSource()
        {
        }
    }
}
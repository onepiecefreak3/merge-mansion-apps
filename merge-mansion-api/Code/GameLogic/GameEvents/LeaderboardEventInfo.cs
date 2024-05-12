using System.Collections.Generic;
using GameLogic.Player.Items;
using GameLogic.Player.Requirements;
using GameLogic.Story;
using Metaplay.Core;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;
using System.Runtime.Serialization;
using GameLogic.Decorations;
using GameLogic.Config;
using GameLogic.Player.Rewards;
using Metaplay.Core.Math;
using Merge;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [MetaActivableConfigData("LeaderboardEvent", false)]
    [MetaBlockedMembers(new int[] { 10, 16 })]
    public class LeaderboardEventInfo : IMetaActivableConfigData<LeaderboardEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<LeaderboardEventId>, IHasGameConfigKey<LeaderboardEventId>, IMetaActivableInfo<LeaderboardEventId>, IBoardEventInfo, IBubbleBonusEvent, IEventGroupInfo
    {
        [MetaMember(1, 0)]
        public LeaderboardEventId LeaderboardEventId { get; set; }

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
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(9, 0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(11, 0)]
        public List<MetaRef<EventLevelInfo>> RankingRewardLevelRefs { get; set; }

        [MetaMember(12, 0)]
        public List<MetaRef<EventLevelInfo>> LevelRefs { get; set; }

        [MetaMember(13, 0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }
        public LeaderboardEventId ConfigKey => LeaderboardEventId;

        [MetaMember(14, (MetaMemberFlags)0)]
        public StoryDefinitionId EndDialogue { get; set; }
        public LeaderboardEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        [IgnoreDataMember]
        public BoardInfo Board { get; }

        [IgnoreDataMember]
        public ItemDefinition PortalItem { get; }

        [IgnoreDataMember]
        public IEnumerable<EventLevelInfo> Levels { get; }
        public OfferPlacementId BoardShopFlashPlacementId { get; }

        [IgnoreDataMember]
        DecorationInfo Code.GameLogic.GameEvents.IBoardEventInfo.ActiveDecoration { get; }

        [IgnoreDataMember]
        ExtendableEventParams Code.GameLogic.GameEvents.IBoardEventInfo.ExtendableEventParams { get; }

        [IgnoreDataMember]
        MetaRef<InAppProductInfo> Code.GameLogic.GameEvents.IBoardEventInfo.ExtensionInAppProduct { get; }

        [IgnoreDataMember]
        MetaDuration Code.GameLogic.GameEvents.IBoardEventInfo.ExtensionPurchaseSafetyMargin { get; }

        [IgnoreDataMember]
        List<PlayerReward> Code.GameLogic.GameEvents.IBoardEventInfo.ExtensionRewards { get; }

        public LeaderboardEventInfo()
        {
        }

        public LeaderboardEventInfo(LeaderboardEventId leaderboardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, int secondaryEnergyAttachmentChance, List<MetaRef<EventLevelInfo>> rankingRewardLevelRefs, List<MetaRef<EventLevelInfo>> levelRefs, StoryDefinitionId enterBoardDialogue, StoryDefinitionId endDialogue)
        {
        }

        [MetaMember(15, (MetaMemberFlags)0)]
        public F32? BubbleBonusDivisor { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public MetaDuration? AuxEnergyUnitRestoreDuration { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public int AuxEnergyAttachmentChance { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public bool DisableBubbleBonus { get; set; }

        [IgnoreDataMember]
        MergeBoardId Code.GameLogic.GameEvents.IBoardEventInfo.MergeBoardId { get; }

        public LeaderboardEventInfo(LeaderboardEventId leaderboardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, List<MetaRef<EventLevelInfo>> rankingRewardLevelRefs, List<MetaRef<EventLevelInfo>> levelRefs, StoryDefinitionId enterBoardDialogue, StoryDefinitionId endDialogue, F32? bubbleBonusDivisor, MetaDuration? auxEnergyUnitRestoreDuration, int auxEnergyAttachmentChance, bool disableBubbleBonus)
        {
        }

        [IgnoreDataMember]
        IStringId Code.GameLogic.GameEvents.IBoardEventInfo.BoardEventId { get; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public List<BubbleBonusInfo> SecondaryBoardBubbleBonus { get; set; }

        public LeaderboardEventInfo(LeaderboardEventId leaderboardEventId, string nameLocId, string displayName, string description, MetaActivableParams activableParams, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, List<MetaRef<EventLevelInfo>> rankingRewardLevelRefs, List<MetaRef<EventLevelInfo>> levelRefs, StoryDefinitionId enterBoardDialogue, StoryDefinitionId endDialogue, MetaDuration? auxEnergyUnitRestoreDuration, int auxEnergyAttachmentChance, EventGroupId eventGroupId, bool disableBubbleBonus, F32? bubbleBonusDivisor, List<BubbleBonusInfo> secondaryBoardBubbleBonus)
        {
        }
    }
}
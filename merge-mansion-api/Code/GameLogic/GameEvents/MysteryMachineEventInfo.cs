using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;
using GameLogic.Player.Requirements;
using System.Collections.Generic;
using Metaplay.Core.Offers;
using GameLogic.Story;
using System.Runtime.Serialization;
using GameLogic.Decorations;
using Merge;
using GameLogic.Config;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaActivableConfigData("MysteryMachineEvent", false, true)]
    [MetaBlockedMembers(new int[] { 10, 11 })]
    [MetaSerializable]
    public class MysteryMachineEventInfo : IMetaActivableConfigData<MysteryMachineEventId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<MysteryMachineEventId>, IHasGameConfigKey<MysteryMachineEventId>, IMetaActivableInfo<MysteryMachineEventId>, IBoardEventInfo, IEventSharedInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineEventId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string NameLocId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MysteryMachineId MysteryMachineId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaRef<BoardInfo> BoardRef { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> PortalItemRef { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public PlayerRequirement UnlockRequirement { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public OfferPlacementId BoardShopPlacementId { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public StoryDefinitionId EnterBoardDialogue { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public StoryDefinitionId StartMachineDialogue { get; set; }
        public MysteryMachineEventId ActivableId { get; }
        public string DisplayShortInfo { get; }

        [IgnoreDataMember]
        public IStringId BoardEventId { get; }

        [IgnoreDataMember]
        public DecorationInfo ActiveDecoration { get; }

        [IgnoreDataMember]
        public int AuxEnergyAttachmentChance { get; }

        [IgnoreDataMember]
        public MergeBoardId MergeBoardId { get; }

        [IgnoreDataMember]
        public ExtendableEventParams ExtendableEventParams { get; }

        [IgnoreDataMember]
        public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; }

        [IgnoreDataMember]
        public MetaDuration ExtensionPurchaseSafetyMargin { get; }

        [IgnoreDataMember]
        public List<PlayerReward> ExtensionRewards { get; }

        [IgnoreDataMember]
        public List<int> ProgressionPopupHeaderImageLevels { get; }

        [IgnoreDataMember]
        public Dictionary<MetaRef<EventLevelInfo>, MetaRef<EventLevelInfo>> FallbackLevelRefs { get; }

        public MysteryMachineEventInfo()
        {
        }

        public MysteryMachineEventInfo(MysteryMachineEventId configKey, string displayName, string description, MetaActivableParams activableParams, string nameLocId, MysteryMachineId mysteryMachineId, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, StoryDefinitionId enterBoardDialogue, StoryDefinitionId startMachineDialogue)
        {
        }

        [MetaMember(15, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineLeaderboardConfigInfo> LeaderboardConfigRef { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public MetaRef<MysteryMachineScreenInfo> ScreenRef { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public EventGroupId GroupId { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public int Priority { get; set; }
        public string SharedEventId { get; }

        public MysteryMachineEventInfo(MysteryMachineEventId configKey, string displayName, string description, MetaActivableParams activableParams, string nameLocId, MysteryMachineId mysteryMachineId, MetaRef<BoardInfo> boardRef, MetaRef<ItemDefinition> portalItemRef, PlayerRequirement unlockRequirement, OfferPlacementId boardShopPlacementId, StoryDefinitionId enterBoardDialogue, StoryDefinitionId startMachineDialogue, MetaRef<MysteryMachineLeaderboardConfigInfo> leaderboardConfigRef, MetaRef<MysteryMachineScreenInfo> screenRef, int priority)
        {
        }
    }
}
using System.Collections.Generic;
using GameLogic.Area;
using GameLogic.Merge;
using GameLogic.Player.Director.Config;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;
using Merge;
using GameLogic.Config.Map.Characters;
using GameLogic.Hotspots.CardStack;

namespace GameLogic.Hotspots
{
    [MetaSerializable]
    public class HotspotDefinition : IGameConfigData<HotspotId>, IGameConfigData, IHasGameConfigKey<HotspotId>, IHasRequirements
    {
        [MetaMember(1, 0)]
        public HotspotId Id { get; set; }

        [MetaMember(2, 0)]
        public HotspotType Type { get; set; }

        [MetaMember(3, 0)]
        public MetaRef<AreaInfo> AreaRef { get; set; }

        [MetaMember(4, 0)]
        public MergeBoardId MergeBoardId { get; set; }

        [MetaMember(5, 0)]
        public List<PlayerRequirement> RequirementsList { get; set; }

        [MetaMember(6, 0)]
        public List<MetaRef<HotspotDefinition>> UnlockingParentRefs { get; set; }

        [MetaMember(7, 0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(8, 0)]
        public List<IDirectorAction> CompletionActions { get; set; }

        [MetaMember(9, 0)]
        public List<IDirectorAction> FinalizationActions { get; set; }

        [MetaMember(10, 0)]
        public List<IDirectorAction> AppearActions { get; set; }
        public HotspotId ConfigKey => Id;

        [IgnoreDataMember]
        public IEnumerable<HotspotDefinition> UnlockingParents { get; }

        [IgnoreDataMember]
        public AreaInfo Area { get; }

        [IgnoreDataMember]
        public bool IsAreaUnlockHotspot { get; }

        [IgnoreDataMember]
        public List<PlayerRequirement> Requirements { get; }

        public HotspotDefinition()
        {
        }

        public HotspotDefinition(HotspotId id, HotspotType type, AreaId area, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions)
        {
        }

        [MetaMember(11, (MetaMemberFlags)0)]
        private MetaRef<MapSpotInfo> MapSpotRef { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public TaskGroupId TaskGroupId { get; set; }

        [IgnoreDataMember]
        public bool IsMergeGoalHotspot { get; }

        [IgnoreDataMember]
        public MapSpotInfo MapSpot { get; }

        [IgnoreDataMember]
        public bool BelongsToTaskGroup { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId)
        {
        }

        [MetaMember(13, (MetaMemberFlags)0)]
        public List<PlayerRequirement> UnlockRequirementsList { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public bool IsIndependentTask { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public int AppearActionMax { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public int CompleteActionMax { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public MetaRef<HotspotDefinition> CompleteFocusHotspotRef { get; set; }

        [IgnoreDataMember]
        public bool IsRepeatableTask { get; }

        [IgnoreDataMember]
        public List<PlayerRequirement> UnlockRequirements { get; }

        [IgnoreDataMember]
        public HotspotDefinition CompleteFocusHotspot { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, int completeActionMax, HotspotId completeFocusHotspotId)
        {
        }

        [MetaMember(18, (MetaMemberFlags)0)]
        public List<MetaRef<MapCharacterEventDefinition>> AppearMapCharactersEventsRefs { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        public List<MetaRef<MapCharacterEventDefinition>> CompleteMapCharactersEventsRefs { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        public MetaDuration BonusTimerDuration { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public List<PlayerReward> BonusRewards { get; set; }

        [IgnoreDataMember]
        public IEnumerable<MapCharacterEventDefinition> AppearMapCharactersEvents { get; }

        [IgnoreDataMember]
        public MapCharacterType AppearMapCharacter { get; }

        [IgnoreDataMember]
        public IEnumerable<MapCharacterEventDefinition> CompleteMapCharactersEvents { get; }

        [IgnoreDataMember]
        public MapCharacterType CompleteMapCharacter { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, List<MetaRef<MapCharacterEventDefinition>> appearMapCharactersEvents, int completeActionMax, HotspotId completeFocusHotspotId, List<MetaRef<MapCharacterEventDefinition>> completeMapCharactersEvents, List<PlayerReward> bonusRewards, MetaDuration bonusTimerDuration)
        {
        }

        [IgnoreDataMember]
        public bool HasVisualCompleteActions { get; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public string CompleteVFXId { get; set; }

        [IgnoreDataMember]
        public bool IsOpenUIHotspot { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, List<MetaRef<MapCharacterEventDefinition>> appearMapCharactersEvents, int completeActionMax, HotspotId completeFocusHotspotId, List<MetaRef<MapCharacterEventDefinition>> completeMapCharactersEvents, List<PlayerReward> bonusRewards, MetaDuration bonusTimerDuration, string completeVFXId)
        {
        }

        [MetaMember(23, (MetaMemberFlags)0)]
        private MetaRef<CardStackInfo> CardStackRef { get; set; }

        [IgnoreDataMember]
        public bool IsCardStackTask { get; }

        [IgnoreDataMember]
        public CardStackInfo CardStackInfo { get; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public string DescriptionLocalizationId { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        private MetaRef<LocationTravelInfo> LocationTravelInfo { get; set; }

        [IgnoreDataMember]
        public bool IsEventHotspot { get; }

        [IgnoreDataMember]
        public bool IsLocationTravelHotspot { get; }

        [IgnoreDataMember]
        public LocationTravelInfo LocationTravel { get; }

        [IgnoreDataMember]
        public string DescriptionLocId { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, List<MetaRef<MapCharacterEventDefinition>> appearMapCharactersEvents, int completeActionMax, HotspotId completeFocusHotspotId, List<MetaRef<MapCharacterEventDefinition>> completeMapCharactersEvents, List<PlayerReward> bonusRewards, MetaDuration bonusTimerDuration, string completeVFXId, string descriptionLocalizationId, LocationTravelId locationTravelId)
        {
        }

        [MetaMember(26, (MetaMemberFlags)0)]
        private MetaRef<AreaInfo> AreaInfoOverride { get; set; }

        [IgnoreDataMember]
        public AreaInfo MapSpotArea { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, List<MetaRef<MapCharacterEventDefinition>> appearMapCharactersEvents, int completeActionMax, HotspotId completeFocusHotspotId, List<MetaRef<MapCharacterEventDefinition>> completeMapCharactersEvents, List<PlayerReward> bonusRewards, MetaDuration bonusTimerDuration, string completeVFXId, string descriptionLocalizationId, LocationTravelId locationTravelId, AreaId areaInfoOverride)
        {
        }

        [MetaMember(27, (MetaMemberFlags)0)]
        private CustomHotspotTableId CustomHotspotTableId { get; set; }

        [IgnoreDataMember]
        public bool IsIllustrationParentTask { get; }

        [IgnoreDataMember]
        public bool IsIllustrationChildTask { get; }

        [IgnoreDataMember]
        public CustomHotspotTableId HotspotTableId { get; }

        public HotspotDefinition(HotspotId id, HotspotType type, MergeBoardId mergeBoardId, List<PlayerRequirement> requirements, IEnumerable<HotspotId> unlockingParents, List<PlayerReward> rewards, List<IDirectorAction> completionActions, List<IDirectorAction> finalizationActions, List<IDirectorAction> appearActions, MapSpotId mapSpot, TaskGroupId taskGroupId, List<PlayerRequirement> unlockRequirements, bool isIndependentTask, int appearActionMax, List<MetaRef<MapCharacterEventDefinition>> appearMapCharactersEvents, int completeActionMax, HotspotId completeFocusHotspotId, List<MetaRef<MapCharacterEventDefinition>> completeMapCharactersEvents, List<PlayerReward> bonusRewards, MetaDuration bonusTimerDuration, string completeVFXId, string descriptionLocalizationId, LocationTravelId locationTravelId, AreaId areaInfoOverride, CustomHotspotTableId customHotspotTableId)
        {
        }
    }
}
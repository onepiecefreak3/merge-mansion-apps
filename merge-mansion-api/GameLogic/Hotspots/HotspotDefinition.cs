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

namespace GameLogic.Hotspots
{
    [MetaSerializable]
    public class HotspotDefinition : IGameConfigData<HotspotId>, IGameConfigData, IGameConfigKey<HotspotId>, IHasRequirements
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
    }
}
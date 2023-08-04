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
    public class HotspotDefinition : IGameConfigData<HotspotId>, IGameConfigData, IHasRequirements
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
        private List<HotspotDefinition> opensAfterCompletion;
        [IgnoreDataMember]
        public IEnumerable<HotspotDefinition> OpensAfterCompletion { get; }

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Hotspots
{
    public class HotspotDefinition : IGameConfigData<HotspotId>, IHasRequirements
    {
        [MetaMember(1, 0)]
        public HotspotId Id { get; set; }
        [MetaMember(2, 0)]
        public HotspotType Type { get; set; }
        [MetaMember(3, 0)]
        private MetaRef<AreaInfo> AreaRef { get; set; }
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
    }
}

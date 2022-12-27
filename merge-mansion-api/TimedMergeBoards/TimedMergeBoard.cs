using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Events;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.TimedMergeBoards
{
    public class TimedMergeBoard : IGameConfigData<MergeBoardId>
    {
        [MetaMember(1, 0)]
        private MergeBoardId Id { get; set; }
        [MetaMember(2, 0)]
        public MetaDuration Duration { get; set; }
        [MetaMember(3, 0)]
        private MergeBoardGeneratorId GeneratorId { get; set; }
        [MetaMember(4, 0)]
        private List<PlayerRequirement> PlayerRequirements { get; set; }
        [MetaMember(5, 0)]
        public MetaRef<ItemDefinition> FinalItemId { get; set; }
        [MetaMember(6, 0)]
        public List<PlayerRequirement> CompletesRequirements { get; set; }

        public MergeBoardId ConfigKey => Id;
    }
}

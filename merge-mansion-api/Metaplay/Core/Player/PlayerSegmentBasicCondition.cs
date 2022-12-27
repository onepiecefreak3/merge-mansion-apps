using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    public class PlayerSegmentBasicCondition : PlayerCondition
    {
        [MetaMember(1)]
        public List<PlayerPropertyRequirement> PropertyRequirements { get; set; }
        [MetaMember(2)]
        public List<PlayerSegmentId> RequireAnySegment { get; set; }
        [MetaMember(3)]
        public List<PlayerSegmentId> RequireAllSegments { get; set; }
	}
}

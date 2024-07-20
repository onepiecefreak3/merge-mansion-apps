using System.Collections.Generic;
using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(1000)]
    public class PlayerSegmentBasicCondition : PlayerCondition
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<PlayerPropertyRequirement> PropertyRequirements { get; set; }

        [MetaMember(2)]
        public List<PlayerSegmentId> RequireAnySegment { get; set; }

        [MetaMember(3)]
        public List<PlayerSegmentId> RequireAllSegments { get; set; }

        private PlayerSegmentBasicCondition()
        {
        }

        public PlayerSegmentBasicCondition(List<PlayerPropertyRequirement> propertyRequirements, List<PlayerSegmentId> requireAnySegment, List<PlayerSegmentId> requireAllSegments)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Hotspots;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(50)]
    public class HotspotNotVisibleRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixRef")]
        private MetaRef<HotspotDefinition> hotspot;
        public HotspotNotVisibleRequirement()
        {
        }

        public HotspotNotVisibleRequirement(HotspotId hotspot)
        {
        }
    }
}
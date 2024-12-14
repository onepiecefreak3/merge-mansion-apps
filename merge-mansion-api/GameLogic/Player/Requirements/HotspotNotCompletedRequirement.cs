using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Hotspots;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(24)]
    public class HotspotNotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixRef")]
        private MetaRef<HotspotDefinition> hotspot;
        public HotspotNotCompletedRequirement()
        {
        }

        public HotspotNotCompletedRequirement(HotspotId hotspot)
        {
        }
    }
}
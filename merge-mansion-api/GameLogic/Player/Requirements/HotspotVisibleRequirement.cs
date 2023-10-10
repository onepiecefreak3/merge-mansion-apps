using GameLogic.Hotspots;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(3)]
    public class HotspotVisibleRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<HotspotDefinition> hotspot;
        public HotspotVisibleRequirement()
        {
        }

        public HotspotVisibleRequirement(HotspotDefinition hotspot)
        {
        }

        // CUSTOM: Copied from HotspotCompletedRequirement
        public MetaRef<HotspotDefinition> GetRequiredHotspot()
        {
            return hotspot;
        }

        public HotspotVisibleRequirement(HotspotId hotspot)
        {
        }
    }
}
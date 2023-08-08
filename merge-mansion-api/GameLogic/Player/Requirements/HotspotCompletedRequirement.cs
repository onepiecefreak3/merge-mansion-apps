using GameLogic.Hotspots;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class HotspotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<HotspotDefinition> hotspot;
        public HotspotCompletedRequirement()
        {
        }

        public HotspotCompletedRequirement(HotspotDefinition hotspot)
        {
        }

        public MetaRef<HotspotDefinition> GetRequiredHotspot()
        {
            return hotspot;
        }
    }
}
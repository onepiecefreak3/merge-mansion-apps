using Game.Cloud.Config;
using GameLogic.Hotspots;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(2)]
    public class HotspotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixRef")]
        private HotspotDef hotspot;
        public HotspotCompletedRequirement()
        {
        }

        public HotspotCompletedRequirement(HotspotDefinition hotspot)
        {
        }

        public HotspotDef GetRequiredHotspot()
        {
            return hotspot;
        }

        public HotspotCompletedRequirement(HotspotId hotspot)
        {
        }
    }
}
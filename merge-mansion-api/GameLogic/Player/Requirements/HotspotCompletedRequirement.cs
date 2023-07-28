using GameLogic.Hotspots;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class HotspotCompletedRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<HotspotDefinition> hotspot { get; set; } // 0x10
    }
}

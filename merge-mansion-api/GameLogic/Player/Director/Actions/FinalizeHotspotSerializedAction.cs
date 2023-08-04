using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Hotspots;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(1)]
    public class FinalizeHotspotSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<HotspotDefinition> Hotspot { get; set; }

        private FinalizeHotspotSerializedAction()
        {
        }

        public FinalizeHotspotSerializedAction(MetaRef<HotspotDefinition> hotspot)
        {
        }
    }
}
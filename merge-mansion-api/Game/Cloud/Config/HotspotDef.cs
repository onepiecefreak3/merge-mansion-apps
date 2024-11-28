using Metaplay.Core.Model;
using GameLogic;
using GameLogic.Hotspots;

namespace Game.Cloud.Config
{
    [MetaSerializableDerived(1)]
    public class HotspotDef : ConfigDefinition<HotspotId, HotspotDefinition>
    {
        public HotspotDef(HotspotId key)
        {
        }

        private HotspotDef()
        {
        }
    }
}
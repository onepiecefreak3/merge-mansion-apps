using Metaplay.Core.Model;
using GameLogic.Area;
using Code.GameLogic.Hotspots;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(42)]
    public class CompleteIllustrationRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CustomHotspotTableId IllustrationId { get; set; }
        public CustomHotspotTableId Illustration => IllustrationId;

        public CompleteIllustrationRequirement()
        {
        }

        public CompleteIllustrationRequirement(CustomHotspotTableId tableId)
        {
        }
    }
}
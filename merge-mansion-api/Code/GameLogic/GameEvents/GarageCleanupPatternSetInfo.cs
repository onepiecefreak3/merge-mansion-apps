using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupPatternSetInfo : IGameConfigData<GarageCleanupPatternSetId>, IGameConfigData, IHasGameConfigKey<GarageCleanupPatternSetId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupPatternSetId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternInfo> Pattern1 { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternInfo> Pattern2 { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternInfo> Pattern3 { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternInfo> Pattern4 { get; set; }

        public GarageCleanupPatternSetInfo()
        {
        }

        public GarageCleanupPatternSetInfo(GarageCleanupPatternSetId patternSetId, List<GarageCleanupPatternInfo> pattern1, List<GarageCleanupPatternInfo> pattern2, List<GarageCleanupPatternInfo> pattern3, List<GarageCleanupPatternInfo> pattern4)
        {
        }
    }
}
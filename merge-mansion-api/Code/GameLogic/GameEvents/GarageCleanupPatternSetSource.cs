using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    public class GarageCleanupPatternSetSource : IConfigItemSource<GarageCleanupPatternSetInfo, GarageCleanupPatternSetId>, IGameConfigSourceItem<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo>, IHasGameConfigKey<GarageCleanupPatternSetId>
    {
        public GarageCleanupPatternSetId ConfigKey { get; set; }
        private List<GarageCleanupPatternId> Pattern1 { get; set; }
        private GarageCleanupRewardId Pattern1Reward { get; set; }
        private string Pattern1LocKey { get; set; }
        private List<GarageCleanupPatternId> Pattern2 { get; set; }
        private GarageCleanupRewardId Pattern2Reward { get; set; }
        private string Pattern2LocKey { get; set; }
        private List<GarageCleanupPatternId> Pattern3 { get; set; }
        private GarageCleanupRewardId Pattern3Reward { get; set; }
        private string Pattern3LocKey { get; set; }
        private List<GarageCleanupPatternId> Pattern4 { get; set; }
        private GarageCleanupRewardId Pattern4Reward { get; set; }
        private string Pattern4LocKey { get; set; }
        public string KeyAsString { get; }

        public GarageCleanupPatternSetSource()
        {
        }
    }
}
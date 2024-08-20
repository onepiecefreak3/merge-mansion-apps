using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class SoloMilestoneMilestonesInfoSource : IConfigItemSource<SoloMilestoneMilestonesInfo, SoloMilestoneMilestonesId>, IGameConfigSourceItem<SoloMilestoneMilestonesId, SoloMilestoneMilestonesInfo>, IHasGameConfigKey<SoloMilestoneMilestonesId>
    {
        public SoloMilestoneMilestonesId ConfigKey { get; set; }
        public int Requirement { get; set; }
        private List<string> RewardSegment { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }

        public SoloMilestoneMilestonesInfoSource()
        {
        }
    }
}
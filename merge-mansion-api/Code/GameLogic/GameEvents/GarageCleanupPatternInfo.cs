using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class GarageCleanupPatternInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupPatternId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<GarageCleanupPatternRowId> Rows { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string NameLocKey { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public GarageCleanupRewardId RewardId { get; set; }

        public GarageCleanupPatternInfo()
        {
        }

        public GarageCleanupPatternInfo(GarageCleanupPatternId patternId, List<GarageCleanupPatternRowId> rows, GarageCleanupRewardId rewardId, string nameLocKey)
        {
        }
    }
}
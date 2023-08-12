using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class FishingSettings : GameConfigKeyValue<FishingSettings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<int, int> SmallFishWaterDropletCounts { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, int> NonFishWaterDropletCounts { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int[] FishWeightCategoryOdds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int[] FishWeightCategorySizePercentages { get; set; }

        public FishingSettings()
        {
        }
    }
}
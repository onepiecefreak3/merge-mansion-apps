using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Items.Production;
using GameLogic.Player.Board.Placement;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class FishingRodFeatures
    {
        public static FishingRodFeatures NoFishingRodFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsFishingRod { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<ItemOdds> ItemOdds { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public IPlacement Placement { get; set; }

        private FishingRodFeatures()
        {
        }

        public FishingRodFeatures(bool isFishingRod, IEnumerable<ValueTuple<int, int>> itemWeightPairs)
        {
        }
    }
}
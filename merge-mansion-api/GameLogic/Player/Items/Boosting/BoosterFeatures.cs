using System.Collections.Generic;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Boosting
{
    [MetaSerializable]
    public sealed class BoosterFeatures
    {
        [MetaMember(1, 0)]
        public bool DoesBoost { get; set; }

        [MetaMember(2, 0)]
        public BoostAreaStyle BoostAreaStyle { get; set; }

        [MetaMember(3, 0)]
        public List<ItemTypeConstant> AffectedItemsSet { get; set; }

        [MetaMember(4, 0)]
        public F32 BoostFactor { get; set; }

        public static BoosterFeatures NoBoost;
        private BoosterFeatures()
        {
        }

        public BoosterFeatures(bool boosts, BoostAreaStyle areaStyle, float factor)
        {
        }

        public BoosterFeatures(bool boosts, BoostAreaStyle areaStyle, float factor, int[] affectedItems)
        {
        }

        public BoosterFeatures(BoostAreaStyle boostAreaStyle, List<int> affectedItemsSet, F32 boostFactor)
        {
        }
    }
}
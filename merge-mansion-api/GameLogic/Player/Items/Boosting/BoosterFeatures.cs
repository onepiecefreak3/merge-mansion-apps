using System.Collections.Generic;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Boosting
{
    [MetaSerializable]
    public class BoosterFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool DoesBoost { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public BoostAreaStyle BoostAreaStyle { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<int> AffectedItemsSet { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
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

        [MetaMember(5, (MetaMemberFlags)0)]
        public F32 SpawnBoostFactor { get; set; }

        public BoosterFeatures(bool boosts, BoostAreaStyle areaStyle, float factor, float spawnFactor)
        {
        }

        public BoosterFeatures(BoostAreaStyle boostAreaStyle, List<int> affectedItemsSet, F32 boostFactor, F32 spawnFactor)
        {
        }
    }
}
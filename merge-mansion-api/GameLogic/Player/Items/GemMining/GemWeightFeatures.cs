using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;
using GameLogic.Story;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.GemMining
{
    [MetaSerializable]
    public class GemWeightFeatures
    {
        public static GemWeightFeatures NoGemWeightFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool HasWeight { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 MinWeight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 MaxWeight { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public GemRarity GemRarity { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsCutGem { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<GemWeightRewardData> WeightRewards { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public F32 CutMultiplier { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public F32 WorldRecordWeightThreshold { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public StoryDefinitionId WorldRecordWeightDialogue { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<PlayerReward> WorldRecordRewards { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public GemPalette GemPalette { get; set; }

        private GemWeightFeatures()
        {
        }

        public GemWeightFeatures(bool hasWeight, F32 minWeight, F32 maxWeight, GemRarity gemRarity, bool isCutGem, List<GemWeightRewardData> weightRewards, F32 cutMultiplier, F32 worldRecordWeightThreshold, StoryDefinitionId worldRecordWeightDialogue, IEnumerable<PlayerReward> worldRecordRewards, GemPalette gemPalette)
        {
        }
    }
}
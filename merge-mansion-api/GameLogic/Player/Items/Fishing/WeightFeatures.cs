using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;
using GameLogic.Story;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class WeightFeatures
    {
        public static WeightFeatures NoWeightFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool HasWeight { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 MinWeight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 MaxWeight { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int FramesItem { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public F32 WorldRecordWeightThreshold { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public StoryDefinitionId WorldRecordWeightDialogue { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<PlayerReward> WorldRecordRewards { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public Dictionary<WeightCategory, SplashType> SplashTypesByWeightCategory { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public FishRarity FishRarity { get; set; }

        private WeightFeatures()
        {
        }

        public WeightFeatures(bool hasWeight, F32 minWeight, F32 maxWeight, int framesItem, F32 worldRecordWeightThreshold, StoryDefinitionId worldRecordWeightDialogue, IEnumerable<PlayerReward> worldRecordRewards, Dictionary<WeightCategory, SplashType> splashTypesByWeightCategory, FishRarity fishRarity)
        {
        }
    }
}
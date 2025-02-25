using System;
using System.Collections.Generic;
using Metaplay.Core.Math;
using GameLogic.Story;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.GemMining
{
    public interface IGemWeightFeatures
    {
        bool HasWeight { get; }

        GemRarity GemRarity { get; }

        bool IsCutGem { get; }

        IReadOnlyList<GemWeightRewardData> WeightRewards { get; }

        F32 CutMultiplier { get; }

        F32 WorldRecordWeightThreshold { get; }

        StoryDefinitionId WorldRecordWeightDialogue { get; }

        IReadOnlyList<PlayerReward> WorldRecordRewards { get; }

        GemPalette GemPalette { get; }

        int GemDisplayPriority { get; }
    }
}
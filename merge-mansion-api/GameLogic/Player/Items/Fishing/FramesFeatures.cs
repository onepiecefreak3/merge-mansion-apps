using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class FramesFeatures
    {
        public static FramesFeatures NoFramesFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsFrames { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int WeightItem { get; set; }

        private FramesFeatures()
        {
        }

        public FramesFeatures(bool isFrames, int weightItem)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.TheGreatEscape
{
    [MetaSerializable]
    public class PostBoxFeatures
    {
        public static PostBoxFeatures NoPostBoxFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsPostBox { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, int> SinkData { get; set; }

        private PostBoxFeatures()
        {
        }

        public PostBoxFeatures(bool isPostBox, Dictionary<int, int> sinkData)
        {
        }
    }
}
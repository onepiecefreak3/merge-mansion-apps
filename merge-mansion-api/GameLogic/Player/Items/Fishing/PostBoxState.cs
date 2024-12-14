using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Fishing
{
    [MetaSerializable]
    public class PostBoxState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsPostBox { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, int> ItemData { get; set; }

        private PostBoxState()
        {
        }

        public PostBoxState(bool isPostBox, Dictionary<int, int> itemData)
        {
        }
    }
}
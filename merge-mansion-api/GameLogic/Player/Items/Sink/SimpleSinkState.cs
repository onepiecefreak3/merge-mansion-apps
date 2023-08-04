using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(1)]
    public class SimpleSinkState : ISinkState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int progress;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int target;
        [MetaMember(3, (MetaMemberFlags)0)]
        private Dictionary<int, int> takeInScores;
        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> rewardItem;
        public ItemDefinition CompletionItem { get; }

        public SimpleSinkState()
        {
        }

        public SimpleSinkState(Dictionary<int, int> takeIn, int scoreTarget, ItemDefinition reward)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(5)]
    public class TagSinkState : ISinkState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<int, int> Progress;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int TargetCount;
        [MetaMember(3, (MetaMemberFlags)0)]
        private int CurrentCount;
        [MetaMember(4, (MetaMemberFlags)0)]
        private int CurrentPoints;
        [MetaMember(5, (MetaMemberFlags)0)]
        private string RewardTagName;
        [MetaMember(6, (MetaMemberFlags)0)]
        public string Tag;
        private ItemDefinition CompletionItemCached;
        public TagSinkState()
        {
        }

        public TagSinkState(string tag, int targetCount, string rewardTagName)
        {
        }

        public int GetCurrentPoints { get; }
    }
}
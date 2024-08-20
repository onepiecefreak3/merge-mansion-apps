using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(5)]
    public class TagSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private string Tag;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int InputCount;
        [MetaMember(3, (MetaMemberFlags)0)]
        private string RewardTagName;
        public IEnumerable<ValueTuple<ItemDefinition, int>> SinkProducts { get; }

        private TagSinkStateFactory()
        {
        }

        public TagSinkStateFactory(string tag, string rewardTagName, int inputCount)
        {
        }
    }
}
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(2)]
    public class SingleTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Dictionary<ItemTypeConstant, int> Scores { get; set; }

        [MetaMember(2, 0)]
        public int ScoreTarget { get; set; }

        [MetaMember(3, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }

        private SingleTargetSinkStateFactory()
        {
        }

        public SingleTargetSinkStateFactory(Dictionary<int, int> scores, int scoreTarget, int reward)
        {
        }

        public IEnumerable<ValueTuple<ItemDefinition, int>> SinkProducts { get; }

        public SingleTargetSinkStateFactory(List<ValueTuple<int, int>> scores, int scoreTarget, int reward)
        {
        }
    }
}
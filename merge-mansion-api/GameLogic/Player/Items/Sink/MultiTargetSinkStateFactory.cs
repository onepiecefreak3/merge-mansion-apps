using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(3)]
    public class MultiTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemTypeConstant, int> ScoreTargets { get; set; }

        [MetaMember(2, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }

        private MultiTargetSinkStateFactory()
        {
        }

        public MultiTargetSinkStateFactory(Dictionary<int, int> scoreTargets, int reward)
        {
        }

        public IEnumerable<ValueTuple<ItemDefinition, int>> SinkProducts { get; }

        public MultiTargetSinkStateFactory(List<ValueTuple<int, int>> scores, int reward)
        {
        }
    }
}
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(4)]
    public class ExclusiveTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<ExclusiveTargetSinkBranch> Branches { get; set; }
        public IEnumerable<ValueTuple<ItemDefinition, int>> SinkProducts { get; }

        private ExclusiveTargetSinkStateFactory()
        {
        }

        public ExclusiveTargetSinkStateFactory(List<ValueTuple<int, int>> scores, List<int> rewardItemIds)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(4)]
    public class ExclusiveTargetSinkState : ISinkState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<int, int> progress;
        [MetaMember(2, (MetaMemberFlags)0)]
        private Dictionary<int, MetaRef<ItemDefinition>> rewardItems;
        [MetaMember(3, (MetaMemberFlags)0)]
        private Dictionary<int, int> targets;
        [MetaMember(4, (MetaMemberFlags)0)]
        private int targetItem;
        public ExclusiveTargetSinkState()
        {
        }

        public ExclusiveTargetSinkState(List<ExclusiveTargetSinkBranch> branches)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(3)]
    public class MultiTargetSinkState : ISinkState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<int, int> progress;
        [MetaMember(2, (MetaMemberFlags)0)]
        private Dictionary<int, int> targets;
        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> rewardItem;
        public MultiTargetSinkState()
        {
        }

        public MultiTargetSinkState(Dictionary<int, int> scoreTargets, ItemDefinition reward)
        {
        }
    }
}
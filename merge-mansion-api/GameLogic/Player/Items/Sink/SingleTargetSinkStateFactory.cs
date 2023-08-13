using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(2)]
    public class SingleTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemTypeConstant, int> Scores { get; set; }

        [MetaMember(2, 0)]
        public int ScoreTarget { get; set; }

        [MetaMember(3, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }
        public ItemDefinition SinkProduct { get; }

        private SingleTargetSinkStateFactory()
        {
        }

        public SingleTargetSinkStateFactory(Dictionary<int, int> scores, int scoreTarget, int reward)
        {
        }
    }
}
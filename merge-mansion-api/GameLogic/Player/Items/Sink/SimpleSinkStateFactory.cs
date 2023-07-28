using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class SimpleSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemTypeConstant, int> Scores { get; set; }
        [MetaMember(2, 0)]
        public int ScoreTarget { get; set; }
        [MetaMember(3, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }
    }
}

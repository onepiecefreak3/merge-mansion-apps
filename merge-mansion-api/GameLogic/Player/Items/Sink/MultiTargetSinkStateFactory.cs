using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class MultiTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemTypeConstant, int> ScoreTargets { get; set; }
        [MetaMember(2, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }
    }
}

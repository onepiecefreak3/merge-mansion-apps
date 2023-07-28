using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(7)]
    [MetaSerializable]
    public class PlayerSeenItemRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }
        [MetaMember(2, 0)]
        public int Requirement { get; set; }
    }
}

using System.Collections.Generic;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(16)]
    [MetaSerializable]
    public class ItemNeededAndConsumeRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        private List<ItemTypeConstant> ItemTypes { get; set; }
        [MetaMember(2, 0)]
        public List<MetaRef<ItemDefinition>> ItemRefs { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class PlayerItemRequirement : PlayerRequirement
    {
        [MetaMember(3, 0)]
        private List<ItemTypeConstant> ItemTypes { get; set; }
        [MetaMember(1, 0)]
        private List<MetaRef<ItemDefinition>> ItemRefs { get; set; }
        [MetaMember(2, 0)]
        public int Requirement { get; set; }

        public IReadOnlyCollection<ItemTypeConstant> Items => ItemTypes;
        public IEnumerable<ItemDefinition> ItemDefinitions => ItemRefs.Select(x => x.Ref);
        public ItemDefinition Item => ItemRefs.FirstOrDefault()?.Ref;
    }
}

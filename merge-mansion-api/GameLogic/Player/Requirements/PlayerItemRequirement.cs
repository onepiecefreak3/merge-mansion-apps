using System.Collections.Generic;
using System.Linq;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(1)]
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

        public PlayerItemRequirement()
        {
        }

        public PlayerItemRequirement(int itemId, int requirement)
        {
        }

        public PlayerItemRequirement(IEnumerable<int> itemIds, int requirement)
        {
        }
    }
}
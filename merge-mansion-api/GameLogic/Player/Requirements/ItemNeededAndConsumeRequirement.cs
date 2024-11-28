using System.Collections.Generic;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(16)]
    public class ItemNeededAndConsumeRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<int> ItemTypes { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> ItemRefs { get; set; }
        public ItemDefinition Item { get; }

        public ItemNeededAndConsumeRequirement()
        {
        }

        public ItemNeededAndConsumeRequirement(int itemType)
        {
        }

        public ItemNeededAndConsumeRequirement(IEnumerable<int> itemTypes)
        {
        }

        [IgnoreDataMember]
        public IReadOnlyCollection<int> Items { get; }

        [IgnoreDataMember]
        public IEnumerable<ItemDefinition> ItemDefinitions { get; }
    }
}
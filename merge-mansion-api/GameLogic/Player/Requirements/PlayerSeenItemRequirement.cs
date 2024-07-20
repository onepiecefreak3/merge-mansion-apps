using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(7)]
    public class PlayerSeenItemRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(2, 0)]
        public int Requirement { get; set; }
        public ItemDefinition Item { get; }
        public IEnumerable<ItemDefinition> Items { get; }

        public PlayerSeenItemRequirement()
        {
        }

        public PlayerSeenItemRequirement(int itemRef)
        {
        }
    }
}
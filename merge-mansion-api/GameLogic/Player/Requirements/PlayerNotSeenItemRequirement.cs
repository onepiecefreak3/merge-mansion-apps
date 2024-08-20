using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(49)]
    public class PlayerNotSeenItemRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }
        public ItemDefinition Item { get; }

        public PlayerNotSeenItemRequirement()
        {
        }

        public PlayerNotSeenItemRequirement(int itemRef)
        {
        }
    }
}
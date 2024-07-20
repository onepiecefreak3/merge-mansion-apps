using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(13)]
    public class ItemNeededRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        private ItemNeededRequirement()
        {
        }

        public ItemNeededRequirement(MetaRef<ItemDefinition> itemRef)
        {
        }
    }
}
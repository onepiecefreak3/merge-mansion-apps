using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(13)]
    [MetaSerializable]
    public class ItemNeededRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        private ItemNeededRequirement()
        {
        }

        public ItemNeededRequirement(MetaRef<ItemDefinition> itemRef)
        {
        }
    }
}
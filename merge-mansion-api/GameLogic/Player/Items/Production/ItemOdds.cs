using Metaplay.Core;
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializable]
    public class ItemOdds
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> Type { get; set; } // 0x10

        [MetaMember(2)]
        public int Weight { get; set; } // 0x18

        private ItemOdds()
        {
        }

        public ItemOdds(int type, int weight)
        {
        }

        [IgnoreDataMember]
        public ItemDefinition Item => Type.Ref;

        [IgnoreDataMember]
        public int ConfigKey => Item.ConfigKey;

        public ItemOdds(ItemDefinition itemDefinition, int weight)
        {
        }
    }
}
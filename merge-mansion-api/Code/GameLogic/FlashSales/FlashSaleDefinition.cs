using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player.Requirements;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;
using GameLogic.Config.Costs;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GameLogic;

namespace Code.GameLogic.FlashSales
{
    [MetaSerializable]
    public class FlashSaleDefinition : IGameConfigData<ShopItemId>, IGameConfigData, IGameConfigKey<ShopItemId>, IHasRequirements
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Quantity { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public ICost ItemCost { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private List<PlayerRequirement> PlayerRequirements { get; set; }

        [IgnoreDataMember]
        public List<PlayerRequirement> Requirements { get; }

        [IgnoreDataMember]
        public ItemDefinition Item { get; }

        public FlashSaleDefinition()
        {
        }

        public FlashSaleDefinition(ShopItemId configKey, MetaRef<ItemDefinition> itemRef, int quantity, int weight, ICost itemCost, List<PlayerRequirement> playerRequirements)
        {
        }
    }
}
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
using GameLogic.Player.Rewards;
using GameLogic.Config;
using GameLogic.Player;
using Metaplay.Core.Player;

namespace Code.GameLogic.FlashSales
{
    [MetaBlockedMembers(new int[] { 1, 5, 2, 7, 8 })]
    [MetaSerializable]
    public class FlashSaleDefinition : IGameConfigData<ShopItemId>, IGameConfigData, IHasGameConfigKey<ShopItemId>, IHasRequirements
    {
        [MetaMember(9, (MetaMemberFlags)0)]
        public ShopItemId ConfigKey { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Quantity { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private List<PlayerRequirement> PlayerRequirements { get; set; }

        [IgnoreDataMember]
        public List<PlayerRequirement> Requirements { get; }

        public FlashSaleDefinition()
        {
        }

        public FlashSaleDefinition(ShopItemId configKey, MetaRef<ItemDefinition> itemRef, int quantity, int weight, ICost itemCost, List<PlayerRequirement> playerRequirements)
        {
        }

        public FlashSaleDefinition(ShopItemId configKey, MetaRef<ItemDefinition> itemRef, int quantity, int weight, ICost itemCost, List<PlayerRequirement> playerRequirements, string itemAux0, string itemAux1)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        private List<ICost> ItemCosts { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public PlayerReward Reward { get; set; }

        public FlashSaleDefinition(ShopItemId configKey, PlayerReward reward, int quantity, int weight, List<ICost> itemCost, List<PlayerRequirement> playerRequirements)
        {
        }

        [MetaMember(12, (MetaMemberFlags)0)]
        public List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public ValueTuple<EnergyType, int> SoloMilestoneToken { get; set; }

        public FlashSaleDefinition(ShopItemId configKey, PlayerReward reward, int quantity, int weight, List<ICost> itemCost, List<PlayerRequirement> playerRequirements, List<MetaRef<PlayerSegmentInfo>> segments)
        {
        }
    }
}
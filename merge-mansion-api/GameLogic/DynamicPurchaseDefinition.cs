using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic
{
    [MetaSerializable]
    public class DynamicPurchaseDefinition : IGameConfigData<ShopItemId>, IGameConfigData, IGameConfigKey<ShopItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopItemId ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public ShopItemId ConfigKey => ItemId;

        public DynamicPurchaseDefinition()
        {
        }
    }
}
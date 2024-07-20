using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace GameLogic
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 1 })]
    public class DynamicPurchaseDefinition : IGameConfigData<ShopItemId>, IGameConfigData, IHasGameConfigKey<ShopItemId>
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public ShopItemId ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public ShopItemId ConfigKey => ItemId;

        public DynamicPurchaseDefinition()
        {
        }
    }
}
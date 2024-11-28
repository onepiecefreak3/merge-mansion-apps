using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializableDerived(5)]
    public class OfferShopItem : IOfferShopItem, IShopItem
    {
        private MetaOfferGroupId OfferGroupId { get; set; }
        private MetaOfferId OfferId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaRef<ItemDefinition> RewardItem { get; set; }

        MetaOfferGroupId GameLogic.Config.Shop.Items.IOfferShopItem.OfferGroupId { get; }

        MetaOfferId GameLogic.Config.Shop.Items.IOfferShopItem.OfferId { get; }

        private OfferShopItem()
        {
        }

        public OfferShopItem(MetaOfferGroupId groupId, MetaOfferId offer, ItemDefinition rewardItem)
        {
        }
    }
}
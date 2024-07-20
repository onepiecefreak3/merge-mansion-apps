using Metaplay.Core.Model;
using GameLogic;
using Metaplay.Core.InAppPurchase;

namespace Game.Cloud.Webshop
{
    [MetaSerializableDerived(2)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class WebshopShopItem : WebshopItem
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public ShopItemId Id { get; set; }
        public override InAppProductId ProductId { get; }

        private WebshopShopItem()
        {
        }

        public WebshopShopItem(ShopItemId id)
        {
        }
    }
}
using GameLogic.Config.Shop.Items;

namespace GameLogic.Config.Shop
{
    public interface IShopItemInfo
    {
        ShopItemId ConfigKey { get; }

        IShopItem ActualItem { get; }
    }
}
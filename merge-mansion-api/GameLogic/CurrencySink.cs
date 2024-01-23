using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum CurrencySink
    {
        None = 0,
        BuyMoreEnergyPopup = 1,
        BubblePurchase = 2,
        CleanDust = 3,
        TimeSkip = 4,
        FlashSalePurchase = 5,
        ShopEnergyPurchase = 6,
        ChestFastOpen = 7,
        SpeedUpItem = 8,
        BuyExtraInventorySlot = 9,
        TestCase = 10,
        UndoItemSale = 11,
        ActivateSpawner = 12,
        SupportRemovedFromUser = 13,
        RefreshShopItems = 14,
        ShopEventOfferPurchase = 15,
        GameEventEndedCurrencyConversion = 16,
        HotspotCompleted = 17,
        InfiniteEnergy = 18,
        GarageCleanupEventLevel = 19,
        DailyDealsPurchase = 20,
        BoxesPurchase = 21,
        ShopDiamondPurchase = 22,
        ShopBlueEnergyPurchase = 23,
        BuyMoreBlueEnergyPopup = 24,
        BuyDailyTasksRefresh = 25,
        BuyMorePurpleEnergyPopup = 26,
        BuyRentableInventory = 27,
        ChestsPurchase = 28,
        DecorationShopPurchase = 29,
        DoubleEnergyMode = 30,
        UsedAsSinkItem = 31
    }
}
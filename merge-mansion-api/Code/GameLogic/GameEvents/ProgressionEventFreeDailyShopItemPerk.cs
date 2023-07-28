using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class ProgressionEventFreeDailyShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public ShopItemId ShopItemId { get; set; }
    }
}

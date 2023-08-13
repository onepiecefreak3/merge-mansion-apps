using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    public class ProgressionEventFreeDailyShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public ShopItemId ShopItemId { get; set; }

        public ProgressionEventFreeDailyShopItemPerk()
        {
        }

        public ProgressionEventFreeDailyShopItemPerk(ShopItemId shopItemId)
        {
        }
    }
}
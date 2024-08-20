using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class ProgressionEventFreeDailyShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public ShopItemId ShopItemId { get; set; }

        public ProgressionEventFreeDailyShopItemPerk()
        {
        }

        public ProgressionEventFreeDailyShopItemPerk(ShopItemId shopItemId)
        {
        }
    }
}
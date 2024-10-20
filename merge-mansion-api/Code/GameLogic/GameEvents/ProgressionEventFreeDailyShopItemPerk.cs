using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializableDerived(3)]
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
using Metaplay.Core;
using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class ProgressionEventFreeShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public ShopItemId ShopItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration Interval { get; set; }

        public ProgressionEventFreeShopItemPerk()
        {
        }

        public ProgressionEventFreeShopItemPerk(ShopItemId shopItemId, MetaDuration interval)
        {
        }
    }
}
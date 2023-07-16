using Metaplay;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(3)]
    public class ProgressionEventFreeDailyShopItemPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public ShopItemId ShopItemId { get; set; }
    }
}

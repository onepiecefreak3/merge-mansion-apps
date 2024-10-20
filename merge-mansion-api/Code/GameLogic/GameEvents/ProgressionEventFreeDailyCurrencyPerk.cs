using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(4)]
    public class ProgressionEventFreeDailyCurrencyPerk : ProgressionEventPerk
    {
        public ProgressionEventFreeDailyCurrencyPerk()
        {
        }

        public ProgressionEventFreeDailyCurrencyPerk(MetaDuration interval)
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopItemId ShopItemId { get; set; }

        public ProgressionEventFreeDailyCurrencyPerk(ShopItemId shopItemId)
        {
        }
    }
}
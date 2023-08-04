using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializableDerived(1)]
    public class RealMoneyItem : IShopItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaRef<InAppProductInfo> ProductRef { get; set; }
        public InAppProductInfo Product { get; }

        public RealMoneyItem()
        {
        }

        public RealMoneyItem(MetaRef<InAppProductInfo> productRef)
        {
        }
    }
}
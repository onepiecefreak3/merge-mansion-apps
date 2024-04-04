using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core.InAppPurchase;

namespace Game.Cloud.Webshop
{
    [MetaSerializableDerived(1)]
    public class WebshopOffer : WebshopItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId Id { get; set; }
        public override InAppProductId ProductId { get; }

        private WebshopOffer()
        {
        }

        public WebshopOffer(MetaOfferId id)
        {
        }
    }
}
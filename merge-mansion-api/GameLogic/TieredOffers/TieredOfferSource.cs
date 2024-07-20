using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core.Offers;

namespace GameLogic.TieredOffers
{
    public class TieredOfferSource : IConfigItemSource<TieredOffer, TieredOfferId>, IGameConfigSourceItem<TieredOfferId, TieredOffer>, IHasGameConfigKey<TieredOfferId>
    {
        public TieredOfferId ConfigKey { get; set; }
        private List<MetaOfferId> OfferItem { get; set; }

        public TieredOfferSource()
        {
        }
    }
}
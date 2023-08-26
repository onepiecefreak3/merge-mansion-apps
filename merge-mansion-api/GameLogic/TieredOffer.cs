using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.TieredOffers;
using System.Collections.Generic;
using Metaplay.Core.Offers;

namespace GameLogic
{
    [MetaSerializable]
    public class TieredOffer : IGameConfigData<TieredOfferId>, IGameConfigData
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaOfferId> OfferItems;
        [MetaMember(1, (MetaMemberFlags)0)]
        public TieredOfferId OfferId { get; set; }

        public TieredOfferId ConfigKey => OfferId;

        public TieredOffer()
        {
        }

        public TieredOffer(TieredOfferId id, List<MetaOfferId> items)
        {
        }
    }
}
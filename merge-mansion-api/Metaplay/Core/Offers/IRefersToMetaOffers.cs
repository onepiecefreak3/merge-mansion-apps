using System.Collections.Generic;

namespace Metaplay.Core.Offers
{
    public interface IRefersToMetaOffers
    {
        IEnumerable<MetaOfferId> GetReferencedMetaOffers();
    }
}

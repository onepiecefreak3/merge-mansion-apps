using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Metaplay.Core.Offers
{
    [MetaActivableSet("OfferGroup", true)]
    [MetaSerializableDerived(100)]
    public class DefaultPlayerMetaOfferGroupsModel : PlayerMetaOfferGroupsModelBase<DefaultMetaOfferGroupInfo>
    {
        public DefaultPlayerMetaOfferGroupsModel()
        {
        }
    }
}
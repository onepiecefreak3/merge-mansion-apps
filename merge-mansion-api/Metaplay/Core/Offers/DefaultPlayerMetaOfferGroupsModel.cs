using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Metaplay.Core.Offers
{
    [MetaSerializableDerived(100)]
    [MetaActivableSet("OfferGroup", true)]
    public class DefaultPlayerMetaOfferGroupsModel : PlayerMetaOfferGroupsModelBase<DefaultMetaOfferGroupInfo>
    {
        public DefaultPlayerMetaOfferGroupsModel()
        {
        }
    }
}
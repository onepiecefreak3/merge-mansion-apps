using Metaplay.Core.Model;
using Metaplay.Core.Activables;

namespace Metaplay.Core.Offers
{
    [MetaActivableConfigData("OfferGroup", true, false)]
    [MetaSerializableDerived(100)]
    public class DefaultMetaOfferGroupInfo : MetaOfferGroupInfoBase
    {
        public DefaultMetaOfferGroupInfo()
        {
        }

        public DefaultMetaOfferGroupInfo(MetaOfferGroupSourceConfigItemBase source)
        {
        }
    }
}
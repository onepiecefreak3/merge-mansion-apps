using Metaplay.Core.Activables;

namespace Metaplay.Core.Offers
{
    public interface IPlayerMetaOfferGroups : IMetaActivableSet<MetaOfferGroupId, MetaOfferGroupInfoBase, MetaOfferGroupModelBase>, IMetaActivableSet<MetaOfferGroupId>, IMetaActivableSet
    {
    }
}
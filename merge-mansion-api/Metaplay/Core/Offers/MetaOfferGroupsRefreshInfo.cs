using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    public struct MetaOfferGroupsRefreshInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MetaOfferGroupInfoBase> GroupsToFinalize;
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaOfferGroupInfoBase> GroupsWithOffersToRefresh;
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaOfferGroupInfoBase> GroupsToActivate;
    }
}
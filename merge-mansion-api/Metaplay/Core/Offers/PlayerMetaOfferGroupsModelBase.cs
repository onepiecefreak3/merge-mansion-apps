using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    [MetaReservedMembers(200, 300)]
    public abstract class PlayerMetaOfferGroupsModelBase<TOfferGroupInfo> : MetaActivableSet<MetaOfferGroupId, TOfferGroupInfo, MetaOfferGroupModelBase>, IPlayerMetaOfferGroups, IMetaActivableSet<MetaOfferGroupId, MetaOfferGroupInfoBase, MetaOfferGroupModelBase>, IMetaActivableSet<MetaOfferGroupId>, IMetaActivableSet
    {
        [MetaMember(200, (MetaMemberFlags)0)]
        public Dictionary<MetaOfferId, MetaOfferPerPlayerStateBase> OfferStates { get; set; }

        protected PlayerMetaOfferGroupsModelBase()
        {
        }
    }
}
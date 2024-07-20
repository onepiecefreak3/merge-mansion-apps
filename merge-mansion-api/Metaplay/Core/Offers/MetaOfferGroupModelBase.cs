using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System.Collections.Generic;
using System;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    [MetaReservedMembers(200, 300)]
    public abstract class MetaOfferGroupModelBase : MetaActivableState<MetaOfferGroupId, MetaOfferGroupInfoBase>
    {
        [MetaMember(200, (MetaMemberFlags)0)]
        public sealed override MetaOfferGroupId ActivableId { get; set; }

        [MetaMember(201, (MetaMemberFlags)0)]
        public Dictionary<MetaOfferId, MetaOfferPerGroupStateBase> OfferStates { get; set; }
        public int CurrentActivationIndex { get; }

        protected MetaOfferGroupModelBase()
        {
        }

        public MetaOfferGroupModelBase(MetaOfferGroupInfoBase info)
        {
        }
    }
}
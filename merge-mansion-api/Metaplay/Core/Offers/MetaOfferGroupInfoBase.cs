using System;
using System.Collections.Generic;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class MetaOfferGroupInfoBase : IMetaActivableConfigData<MetaOfferGroupId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<MetaOfferGroupId>, IHasGameConfigKey<MetaOfferGroupId>, IMetaActivableInfo<MetaOfferGroupId>, IGameConfigPostLoad
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public MetaOfferGroupId GroupId { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public OfferPlacementId Placement { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public int Priority { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public List<MetaRef<MetaOfferInfoBase>> Offers { get; set; }

        [MetaMember(106, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }
        public MetaOfferGroupId ConfigKey => GroupId;

        [MetaMember(107, (MetaMemberFlags)0)]
        public int? MaxOffersActive { get; set; }
        public MetaOfferGroupId ActivableId { get; }
        public string DisplayShortInfo { get; }

        protected MetaOfferGroupInfoBase()
        {
        }

        protected MetaOfferGroupInfoBase(MetaOfferGroupId groupId, string displayName, string description, OfferPlacementId placement, int priority, List<MetaRef<MetaOfferInfoBase>> offers, MetaActivableParams activableParams, int? maxOffersActive)
        {
        }

        protected MetaOfferGroupInfoBase(MetaOfferGroupSourceConfigItemBase source)
        {
        }

        [MetaMember(108, (MetaMemberFlags)0)]
        public bool IncludeSoldOutOffers { get; set; }

        protected MetaOfferGroupInfoBase(MetaOfferGroupId groupId, string displayName, string description, OfferPlacementId placement, int priority, List<MetaRef<MetaOfferInfoBase>> offers, MetaActivableParams activableParams, int? maxOffersActive, bool includeSoldOutOffers)
        {
        }
    }
}
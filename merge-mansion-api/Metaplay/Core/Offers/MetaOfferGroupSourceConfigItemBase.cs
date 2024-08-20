using System;
using System.Collections.Generic;
using Metaplay.Core.Player;
using Metaplay.Core.Activables;
using Metaplay.Core.Schedule;
using Metaplay.Core.Config;

namespace Metaplay.Core.Offers
{
    public abstract class MetaOfferGroupSourceConfigItemBase
    {
        public MetaOfferGroupId GroupId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public OfferPlacementId Placement { get; set; }
        public int Priority { get; set; }
        public List<MetaRef<MetaOfferInfoBase>> Offers { get; set; }
        public List<MetaRef<PlayerSegmentInfoBase>> Segments { get; set; }
        public MetaActivableLifetimeSpec Lifetime { get; set; }
        public MetaActivableCooldownSpec Cooldown { get; set; }
        public MetaScheduleBase Schedule { get; set; }
        public int? MaxOffersActive { get; set; }

        protected MetaOfferGroupSourceConfigItemBase()
        {
        }

        public bool IncludeSoldOutOffers { get; set; }
    }

    public abstract class MetaOfferGroupSourceConfigItemBase<TMetaOfferGroupInfo> : MetaOfferGroupSourceConfigItemBase, IGameConfigSourceItem<TMetaOfferGroupInfo>, IMetaIntegrationConstructible<MetaOfferGroupSourceConfigItemBase<TMetaOfferGroupInfo>>, IMetaIntegration<MetaOfferGroupSourceConfigItemBase<TMetaOfferGroupInfo>>, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
    }
}
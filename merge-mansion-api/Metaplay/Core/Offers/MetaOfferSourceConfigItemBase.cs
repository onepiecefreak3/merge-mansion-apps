using System;
using Metaplay.Core.InAppPurchase;
using System.Collections.Generic;
using Metaplay.Core.Rewards;
using Metaplay.Core.Player;
using Metaplay.Core.Config;

namespace Metaplay.Core.Offers
{
    public abstract class MetaOfferSourceConfigItemBase
    {
        public MetaOfferId OfferId;
        public string DisplayName;
        public string Description;
        public MetaRef<InAppProductInfoBase> InAppProduct;
        public List<MetaPlayerRewardBase> Rewards;
        public int? MaxActivations;
        public int? MaxPurchasesPerPlayer;
        public int? MaxPurchasesPerOfferGroup;
        public int? MaxPurchasesPerActivation;
        public List<MetaRef<PlayerSegmentInfoBase>> Segments;
        public List<MetaOfferId> PrecursorId;
        public List<bool> PrecursorConsumed;
        public List<MetaDuration> PrecursorDelay;
        public bool IsSticky;
        protected MetaOfferSourceConfigItemBase()
        {
        }
    }

    public abstract class MetaOfferSourceConfigItemBase<TMetaOfferInfo> : MetaOfferSourceConfigItemBase, IMetaIntegrationConstructible<MetaOfferSourceConfigItemBase<TMetaOfferInfo>>, IMetaIntegration<MetaOfferSourceConfigItemBase<TMetaOfferInfo>>, IMetaIntegrationConstructible, IRequireSingleConcreteType, IGameConfigSourceItem<TMetaOfferInfo>
    {
        protected MetaOfferSourceConfigItemBase()
        {
        }
    }
}
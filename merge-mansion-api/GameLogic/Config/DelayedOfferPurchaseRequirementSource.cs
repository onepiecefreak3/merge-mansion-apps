using Code.GameLogic.Config;
using Metaplay.Core.Offers;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Config
{
    public class DelayedOfferPurchaseRequirementSource : IConfigItemSource<DelayedOfferPurchaseRequirement, MetaOfferId>, IGameConfigSourceItem<MetaOfferId, DelayedOfferPurchaseRequirement>, IHasGameConfigKey<MetaOfferId>
    {
        public MetaOfferId ConfigKey { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }

        public DelayedOfferPurchaseRequirementSource()
        {
        }
    }
}
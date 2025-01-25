using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Offers;
using Code.GameLogic.Config;
using System.Collections.Generic;
using GameLogic.Player.Requirements;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class DelayedOfferPurchaseRequirement : IGameConfigData<MetaOfferId>, IGameConfigData, IHasGameConfigKey<MetaOfferId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerRequirement> Requirements { get; set; }

        public DelayedOfferPurchaseRequirement()
        {
        }

        public DelayedOfferPurchaseRequirement(MetaOfferId configKey, List<PlayerRequirement> requirements)
        {
        }
    }
}
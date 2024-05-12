using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(40)]
    public class OfferGroupTimeRemainingRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaDuration? TimeRemaining { get; set; }

        private OfferGroupTimeRemainingRequirement()
        {
        }

        public OfferGroupTimeRemainingRequirement(MetaOfferGroupId offerGroupId, MetaDuration? timeRemaining)
        {
        }
    }
}
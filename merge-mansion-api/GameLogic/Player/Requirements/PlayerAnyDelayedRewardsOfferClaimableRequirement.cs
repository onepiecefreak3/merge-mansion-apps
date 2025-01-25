using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(57)]
    public class PlayerAnyDelayedRewardsOfferClaimableRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferGroupId GroupId { get; set; }

        public PlayerAnyDelayedRewardsOfferClaimableRequirement()
        {
        }

        public PlayerAnyDelayedRewardsOfferClaimableRequirement(MetaOfferGroupId offerGroupId)
        {
        }
    }
}
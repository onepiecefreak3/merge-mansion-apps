using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(34)]
    public class RewardOfferContents : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        public RewardOfferContents()
        {
        }

        public RewardOfferContents(MetaOfferId offerId, CurrencySource source)
        {
        }
    }
}
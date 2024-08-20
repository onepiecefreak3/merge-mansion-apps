using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System.Collections.Generic;
using Metaplay.Core.Rewards;
using GameLogic.Player.Rewards;
using Metaplay.Core.Offers;

namespace Game.Logic
{
    [MetaBlockedMembers(new int[] { 1, 2 })]
    [MetaSerializableDerived(5)]
    public class MakeYourOwnOfferDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaPlayerRewardBase> StaticRewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerReward> CustomRewards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaOfferGroupInfoBase GroupInfo { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaOfferInfoBase OfferInfo { get; set; }
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        private MakeYourOwnOfferDynamicPurchaseContent()
        {
        }

        public MakeYourOwnOfferDynamicPurchaseContent(MetaOfferGroupInfoBase groupInfo, MetaOfferInfoBase offerInfo, List<MetaPlayerRewardBase> staticRewards, List<PlayerReward> customRewards)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core;
using System.Collections.Generic;
using Metaplay.Core.Rewards;

namespace Game.Logic
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class ShopOfferDynamicPurchaseContent : DynamicPurchaseContent
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime RequestedAt;
        public override List<MetaPlayerRewardBase> PurchaseRewards { get; }

        public ShopOfferDynamicPurchaseContent()
        {
        }
    }
}
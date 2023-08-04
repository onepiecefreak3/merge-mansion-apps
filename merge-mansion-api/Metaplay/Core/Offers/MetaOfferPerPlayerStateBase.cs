using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Offers
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class MetaOfferPerPlayerStateBase
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public int NumActivatedByPlayer { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public int NumPurchasedByPlayer { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public MetaOfferPerPlayerActivation? LatestActivation { get; set; }

        protected MetaOfferPerPlayerStateBase()
        {
        }
    }
}
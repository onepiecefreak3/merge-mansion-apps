using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class MetaOfferPerGroupStateBase
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public int NumActivatedInGroup { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public int NumPurchasedInGroup { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public MetaOfferPerGroupActivation? LatestActivation { get; set; }

        protected MetaOfferPerGroupStateBase()
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    public struct MetaOfferPerPlayerActivation
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public int NumPurchased;
        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime? EndedAt;
    }
}
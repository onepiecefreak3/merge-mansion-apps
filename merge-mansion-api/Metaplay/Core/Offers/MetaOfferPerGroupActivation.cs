using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    public struct MetaOfferPerGroupActivation
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int GroupActivationIndex;
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsActive;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int NumPurchased;
        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime? EndedAt;
    }
}
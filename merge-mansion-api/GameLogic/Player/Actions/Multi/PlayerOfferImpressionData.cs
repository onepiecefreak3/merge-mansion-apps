using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System;

namespace GameLogic.Player.Actions.Multi
{
    [MetaSerializable]
    public struct PlayerOfferImpressionData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaOfferId OfferId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string PlatformId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public OfferPlacementId PlacementId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string PopupTrigger { get; set; }
    }
}
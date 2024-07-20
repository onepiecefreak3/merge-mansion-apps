using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;
using Metaplay.Core.Offers;

namespace GameLogic.Player.Actions.Multi
{
    [MetaSerializable]
    public struct PlayerShopItemIapImpressionData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public InAppProductId ShopItemIapId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string PlatformId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public OfferPlacementId PlacementId { get; set; }
    }
}
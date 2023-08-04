using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using GameLogic.Player;
using System;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializableDerived(6)]
    public class OfferShopEnergyItem : IOfferShopItem, IShopItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private MetaOfferGroupId OfferGroupId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaOfferId OfferId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int EnergyAmount { get; set; }

        MetaOfferGroupId GameLogic.Config.Shop.Items.IOfferShopItem.OfferGroupId { get; }

        MetaOfferId GameLogic.Config.Shop.Items.IOfferShopItem.OfferId { get; }

        private OfferShopEnergyItem()
        {
        }

        public OfferShopEnergyItem(MetaOfferGroupId groupId, MetaOfferId offer, EnergyType energyType, int energyAmount)
        {
        }
    }
}
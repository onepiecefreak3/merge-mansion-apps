using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace GameLogic.Config.Shop.Items
{
    [MetaSerializable]
    public interface IOfferShopItem : IShopItem
    {
        MetaOfferGroupId OfferGroupId { get; }

        MetaOfferId OfferId { get; }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace Metaplay.Core.Offers
{
    [MetaSerializableDerived(1100)]
    [MetaSerializable]
    public class MetaOfferPrecursorCondition : PlayerCondition
    {
        [MetaMember(1, 0)]
        public MetaOfferId OfferId { get; set; }
        [MetaMember(2, 0)]
        public bool Purchased { get; set; }
        [MetaMember(3, 0)]
        public MetaDuration Delay { get; set; }
    }
}

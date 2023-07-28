using Metaplay.Core.Model;
using Metaplay.Core.Offers;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class MergeMansionOfferGroupInfo : MetaOfferGroupInfoBase, IOfferGroupVisuals
    {
        [MetaMember(1, 0)]
        private string OfferTitlePrefabId { get; set; }
        [MetaMember(2, 0)]
        private string BackgroundPrefabId { get; set; }
        [MetaMember(3, 0)]
        private string TitleLocId { get; set; }
        [MetaMember(4, 0)]
        private string OfferButtonPrefabId { get; set; }
        [MetaMember(5, 0)]
        private string OfferContainerPrefabId { get; set; }
        [MetaMember(6, 0)]
        private int FlashSaleWeight { get; set; }
	}
}

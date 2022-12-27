using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.Player.Requirements;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Offers;

namespace Metaplay.GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class MergeMansionOfferInfo : MetaOfferInfoBase, IOfferVisuals
    {
        [MetaMember(1, 0)]
        private string TitleLocId { get; set; }
        [MetaMember(2, 0)]
        private string SaleBadgeLocId { get; set; }
        [MetaMember(3, 0)]
        private string OfferPanePrefabId { get; set; }
        [MetaMember(4, 0)]
        private string BackgroundSpriteId { get; set; }
        [MetaMember(5, 0)]
        public ICost OfferCost { get; set; }
        [MetaMember(6, 0)]
        public int FlashSalePriceModifier { get; set; }
        [MetaMember(7, 0)]
        public int Weight { get; set; }
        [MetaMember(8, 0)]
        public List<PlayerRequirement> Requirements { get; set; }
        [MetaMember(9, 0)]
        public string TitleColorHex { get; set; }
        [MetaMember(10, 0)]
        public string BackgroundColorHex { get; set; }
        [MetaMember(11, 0)]
        public string BackgroundGradientHex { get; set; }
        [MetaMember(12, 0)]
        public string LeftCharacterId { get; set; }
        [MetaMember(13, 0)]
        public string RightCharacterId { get; set; }
	}
}

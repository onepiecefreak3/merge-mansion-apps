using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.Player.Requirements;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System.Runtime.Serialization;
using System;
using System.Linq;
using GameLogic.Player.Rewards;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
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

        [IgnoreDataMember] 
        public CurrencyCost Cost => OfferCost as CurrencyCost;

        public string TitleLocalizationId => TitleLocId;
        public string SaleBadgeLocalizationId => SaleBadgeLocId;
        public string OfferPaneId => OfferPanePrefabId;
        public string BackgroundId => BackgroundSpriteId;
        public IEnumerable<PlayerReward> OfferRewards => Rewards.OfType<PlayerReward>();
        public override bool RequireInAppProduct => false;

        public MergeMansionOfferInfo()
        {
        }

        public MergeMansionOfferInfo(MetaOfferSourceConfigItemBase metaOfferInfo, string titleLocId, string saleBadgeLocId, string offerPanePrefabId, string backgroundSpriteId, string titleColorHex, string backgroundColorHex, string backgroundGradientHex, string leftCharacterId, string rightCharacterId, ICost cost, int flashSalePriceModifier, int weight, List<PlayerRequirement> requirements)
        {
        }
    }
}
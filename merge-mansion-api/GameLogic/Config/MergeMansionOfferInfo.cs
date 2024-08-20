using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.Player.Requirements;
using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using System.Runtime.Serialization;
using System;
using System.Linq;
using GameLogic.Player.Rewards;
using GameLogic.Player.Director.Config;
using Metaplay.Core;
using Metaplay.Core.InAppPurchase;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class MergeMansionOfferInfo : MetaOfferInfoBase, IOfferVisuals
    {
        [MetaMember(1, (MetaMemberFlags)0)]
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

        [MetaMember(14, (MetaMemberFlags)0)]
        public string BackgroundAnimationId { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public string ForegroundEffectId { get; set; }

        public MergeMansionOfferInfo(MetaOfferSourceConfigItemBase metaOfferInfo, string titleLocId, string saleBadgeLocId, string offerPanePrefabId, string backgroundAnimationId, string foregroundEffectId, string backgroundSpriteId, string titleColorHex, string backgroundColorHex, string backgroundGradientHex, string leftCharacterId, string rightCharacterId, ICost cost, int flashSalePriceModifier, int weight, List<PlayerRequirement> requirements)
        {
        }

        [MetaMember(16, (MetaMemberFlags)0)]
        private List<IDirectorAction> FirstTimePurchaseActions { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public List<int> CostAmounts { get; set; }

        public MergeMansionOfferInfo(MetaOfferSourceConfigItemBase metaOfferInfo, string titleLocId, string saleBadgeLocId, string offerPanePrefabId, string backgroundAnimationId, string foregroundEffectId, string backgroundSpriteId, string titleColorHex, string backgroundColorHex, string backgroundGradientHex, string leftCharacterId, string rightCharacterId, ICost cost, List<int> costAmounts, int flashSalePriceModifier, int weight, List<PlayerRequirement> requirements, List<IDirectorAction> firstTimePurchaseActions)
        {
        }

        [MetaMember(18, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfoBase> PreviousInAppProduct { get; set; }

        public MergeMansionOfferInfo(MetaOfferSourceConfigItemBase metaOfferInfo, string titleLocId, string saleBadgeLocId, string offerPanePrefabId, string backgroundAnimationId, string foregroundEffectId, string backgroundSpriteId, string titleColorHex, string backgroundColorHex, string backgroundGradientHex, string leftCharacterId, string rightCharacterId, ICost cost, List<int> costAmounts, int flashSalePriceModifier, int weight, List<PlayerRequirement> requirements, List<IDirectorAction> firstTimePurchaseActions, MetaRef<InAppProductInfoBase> previousInAppProduct)
        {
        }

        [MetaMember(19, (MetaMemberFlags)0)]
        public int MaxPurchasesGlobally { get; set; }

        public MergeMansionOfferInfo(MetaOfferSourceConfigItemBase metaOfferInfo, string titleLocId, string saleBadgeLocId, string offerPanePrefabId, string backgroundAnimationId, string foregroundEffectId, string backgroundSpriteId, string titleColorHex, string backgroundColorHex, string backgroundGradientHex, string leftCharacterId, string rightCharacterId, ICost cost, List<int> costAmounts, int flashSalePriceModifier, int weight, List<PlayerRequirement> requirements, List<IDirectorAction> firstTimePurchaseActions, MetaRef<InAppProductInfoBase> previousInAppProduct, int maxPurchasesGlobally)
        {
        }
    }
}
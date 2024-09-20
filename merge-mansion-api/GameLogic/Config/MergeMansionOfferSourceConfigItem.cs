using Metaplay.Core.Offers;
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.InAppPurchase;

namespace GameLogic.Config
{
    public class MergeMansionOfferSourceConfigItem : MetaOfferSourceConfigItemBase, IConfigItemSource<MergeMansionOfferInfo, MetaOfferId>, IGameConfigSourceItem<MetaOfferId, MergeMansionOfferInfo>, IHasGameConfigKey<MetaOfferId>
    {
        private string TitleLocId { get; set; }
        private string SaleBadgeLocId { get; set; }
        private string OfferPanePrefabId { get; set; }
        private string BackgroundSpriteId { get; set; }
        private string TitleColorHex { get; set; }
        private string BackgroundColorHex { get; set; }
        private string BackgroundGradientHex { get; set; }
        private string BackgroundAnimationId { get; set; }
        private string ForegroundEffectId { get; set; }
        private string LeftCharacterId { get; set; }
        private string RightCharacterId { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private string CostType { get; set; }
        private string CostId { get; set; }
        private List<int> CostAmount { get; set; }
        private int FlashSalePriceModifier { get; set; }
        private int Weight { get; set; }
        private List<string> FirstTimePurchaseAction { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private string OverrideCurrencySource { get; set; }
        public MetaOfferId ConfigKey { get; }

        public MergeMansionOfferSourceConfigItem()
        {
        }

        private MetaRef<InAppProductInfoBase> PreviousInAppProduct { get; set; }
        private int MaxPurchasesGlobally { get; set; }
        private int SaleAmount { get; set; }
    }
}
using GameLogic.IAP;
using Metaplay.Core;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Math;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class InAppProductInfo : InAppProductInfoBase
    {
        [MetaMember(201, (MetaMemberFlags)0)]
        public IAPTags IAPTags { get; set; }

        [MetaMember(202)]
        public MetaRef<DynamicPurchaseDefinition> PurchaseDefinition { get; set; }

        [MetaMember(203)]
        public string LocalizationId { get; set; }

        [MetaMember(204, (MetaMemberFlags)0)]
        public string DiscountLocalizationId { get; set; }
        public ShopItemId ShopItemId { get; }
        public IEnumerable<PlayerReward> Rewards { get; }
        public IEnumerable<ICurrencyReward> Currencies { get; }
        public IEnumerable<RewardItem> Items { get; }
        public ResolvedPurchaseGameContent ResolvedContent { get; }
        public string AnalyticsId { get; }
        public bool IsCurrencyOnly { get; }

        public InAppProductInfo()
        {
        }

        public InAppProductInfo(InAppProductId productId, string name, InAppProductType type, F64 price, bool hasDynamicContent, string developmentId, string googleId, string appleId, IAPTags iapTags, MetaRef<DynamicPurchaseDefinition> purchaseDefinition, string localizationId, string discountLocalizationId)
        {
        }
    }
}
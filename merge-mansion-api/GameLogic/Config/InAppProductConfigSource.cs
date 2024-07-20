using Code.GameLogic.Config;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Math;
using GameLogic.IAP;
using Metaplay.Core;

namespace GameLogic.Config
{
    public class InAppProductConfigSource : IConfigItemSource<InAppProductInfo, InAppProductId>, IGameConfigSourceItem<InAppProductId, InAppProductInfo>, IHasGameConfigKey<InAppProductId>
    {
        private InAppProductId ProductId { get; set; }
        private string Name { get; set; }
        private InAppProductType Type { get; set; }
        private F64 Price { get; set; }
        private bool HasDynamicContent { get; set; }
        private string DevelopmentId { get; set; }
        private string GoogleId { get; set; }
        private string AppleId { get; set; }
        private IAPTags IAPTags { get; set; }
        private MetaRef<DynamicPurchaseDefinition> DynamicPurchase { get; set; }
        private string LocalizationId { get; set; }
        private string DiscountLocalizationId { get; set; }
        public InAppProductId ConfigKey { get; }

        public InAppProductConfigSource()
        {
        }
    }
}
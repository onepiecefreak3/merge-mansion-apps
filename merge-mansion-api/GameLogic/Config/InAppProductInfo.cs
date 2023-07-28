using GameLogic.IAP;
using Metaplay.Core;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class InAppProductInfo : InAppProductInfoBase
    {
        [MetaMember(201)]
        public IAPTags IAPTags { get; set; }
        [MetaMember(202)]
        public MetaRef<DynamicPurchaseDefinition> PurchaseDefinition { get; set; }
        [MetaMember(203)]
        public string LocalizationId { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.IAP;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.InAppPurchase;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Config
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

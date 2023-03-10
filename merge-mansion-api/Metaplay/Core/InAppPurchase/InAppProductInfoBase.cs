using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.InAppPurchase
{
    public abstract class InAppProductInfoBase : IGameConfigData<InAppProductId>
    {
        [MetaMember(100)]
        public InAppProductId ProductId { get; set; }
        [MetaMember(101)]
        public string Name { get; set; }
        [MetaMember(102)]
        public InAppProductType Type { get; set; }
        [MetaMember(103)]
        public F64 Price { get; set; }
        [MetaMember(107)]
        public bool HasDynamicContent { get; set; }
        [MetaMember(104)]
        public string DevelopmentId { get; set; }
        [MetaMember(105)]
        public string GoogleId { get; set; }
        [MetaMember(106)]
        public string AppleId { get; set; }

        public InAppProductId ConfigKey => ProductId;
    }
}

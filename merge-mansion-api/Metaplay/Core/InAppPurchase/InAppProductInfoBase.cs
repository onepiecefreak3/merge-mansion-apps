using Metaplay.Core.Config;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.InAppPurchase
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class InAppProductInfoBase : IGameConfigData<InAppProductId>, IGameConfigData, IHasGameConfigKey<InAppProductId>
    {
        [MetaMember(100, (MetaMemberFlags)0)]
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

        public InAppProductInfoBase()
        {
        }

        public InAppProductInfoBase(InAppProductId productId, string name, InAppProductType type, F64 price, bool hasDynamicContent, string developmentId, string googleId, string appleId)
        {
        }
    }
}
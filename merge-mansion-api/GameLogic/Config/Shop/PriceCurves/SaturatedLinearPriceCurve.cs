using Metaplay.Core.Model;
using Metaplay.Core.Math;
using GameLogic.Config.Shop.PurchaseLimiters;

namespace GameLogic.Config.Shop.PriceCurves
{
    [MetaSerializableDerived(2)]
    public class SaturatedLinearPriceCurve : IPriceCurve
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private F64 MaxPrice { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private F64 BasePrice { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private F64 Increment { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }

        public SaturatedLinearPriceCurve()
        {
        }

        public SaturatedLinearPriceCurve(Currencies currency, F64 maxPrice, F64 basePrice, F64 increment, IPurchaseLimiter purchaseLimiter)
        {
        }
    }
}
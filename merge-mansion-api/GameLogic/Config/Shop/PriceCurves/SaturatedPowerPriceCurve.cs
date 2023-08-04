using Metaplay.Core.Model;
using Metaplay.Core.Math;
using GameLogic.Config.Shop.PurchaseLimiters;
using System;

namespace GameLogic.Config.Shop.PriceCurves
{
    [MetaSerializableDerived(5)]
    public class SaturatedPowerPriceCurve : IPriceCurve
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private F64 Base { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private F64 Quotient { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private F64 Max { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }
        private int MaxPower { get; }

        private SaturatedPowerPriceCurve()
        {
        }

        public SaturatedPowerPriceCurve(Currencies currency, F64 @base, F64 quotient, F64 max, IPurchaseLimiter purchaseLimiter)
        {
        }
    }
}
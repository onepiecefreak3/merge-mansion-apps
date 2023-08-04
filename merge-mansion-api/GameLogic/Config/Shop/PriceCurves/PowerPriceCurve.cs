using Metaplay.Core.Model;
using Metaplay.Core.Math;
using GameLogic.Config.Shop.PurchaseLimiters;
using System;

namespace GameLogic.Config.Shop.PriceCurves
{
    [MetaSerializableDerived(4)]
    public class PowerPriceCurve : IPriceCurve
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private F64 Base { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private F64 Quotient { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private IPurchaseLimiter PurchaseLimiter { get; set; }
        private int MaxPower { get; }

        private PowerPriceCurve()
        {
        }

        public PowerPriceCurve(Currencies currency, F64 @base, F64 quotient, IPurchaseLimiter purchaseLimiter)
        {
        }
    }
}
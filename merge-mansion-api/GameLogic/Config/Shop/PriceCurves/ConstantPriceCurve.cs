using Metaplay.Core.Model;
using Metaplay.Core.Math;
using GameLogic.Config.Costs;

namespace GameLogic.Config.Shop.PriceCurves
{
    [MetaSerializableDerived(1)]
    public class ConstantPriceCurve : IPriceCurve
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private F64 Price { get; set; }

        public ConstantPriceCurve()
        {
        }

        public ConstantPriceCurve(CurrencyCost currencyCost)
        {
        }

        public ConstantPriceCurve(Currencies currency, F64 price)
        {
        }
    }
}
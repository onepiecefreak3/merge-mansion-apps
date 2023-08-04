using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class SpeedUpCostBehavior
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F64 SecondsPerGem { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F64 FirstDiscount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F64 FirstDiscountTime { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public F64 SecondDiscount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public F64 SecondDiscountTime { get; set; }

        public SpeedUpCostBehavior()
        {
        }

        public SpeedUpCostBehavior(F64 secondsPerGem, F64 firstDiscount, F64 firstDiscountTime, F64 secondDiscount, F64 secondDiscountTime)
        {
        }
    }
}
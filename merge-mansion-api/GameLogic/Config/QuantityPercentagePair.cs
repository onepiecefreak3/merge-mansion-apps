using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class QuantityPercentagePair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public F32 Quantity { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 Percentage { get; set; }

        public QuantityPercentagePair()
        {
        }

        public QuantityPercentagePair(F32 quantity, F32 percentage)
        {
        }
    }
}
using Metaplay.Core.Model;

namespace GameLogic.Config.Costs
{
    [MetaSerializable]
    public abstract class CurrencyCost : ICost
    {
        [MetaMember(1, 0)]
        public long CurrencyAmount { get; set; }
    }
}

using Metaplay.Core.Model;

namespace GameLogic.Config.Costs
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class GameCurrencyCost : CurrencyCost
    {
        [MetaMember(2, 0)]
        public Currencies Type { get; set; }
    }
}

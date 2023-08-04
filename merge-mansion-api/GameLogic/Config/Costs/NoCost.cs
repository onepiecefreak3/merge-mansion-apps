using Metaplay.Core.Model;

namespace GameLogic.Config.Costs
{
    [MetaSerializableDerived(3)]
    public class NoCost : CurrencyCost
    {
        public override Currencies Currency => Currencies.None;

        public NoCost()
        {
        }
    }
}
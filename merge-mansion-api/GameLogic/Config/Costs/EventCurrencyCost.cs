using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;

namespace GameLogic.Config.Costs
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class EventCurrencyCost : CurrencyCost
    {
        [MetaMember(2, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
    }
}

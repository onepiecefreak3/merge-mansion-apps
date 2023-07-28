using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1034)]
    [MetaSerializable]
    public class PlayerEventCurrencyAmount : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, 0)]
        private EventCurrencyId CurrencyId { get; set; }
    }
}

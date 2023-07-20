using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.GameLogic.Config
{
    [MetaSerializableDerived(1034)]
    [MetaSerializable]
    public class PlayerEventCurrencyAmount : TypedPlayerPropertyId<long>
    {
        [MetaMember(1, 0)]
        private EventCurrencyId CurrencyId { get; set; }
    }
}

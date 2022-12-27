using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Config.Costs
{
    [MetaSerializableDerived(2)]
    public class EventCurrencyCost : CurrencyCost
    {
        [MetaMember(2, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
    }
}

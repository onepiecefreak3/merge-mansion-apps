using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Config.Costs
{
    [MetaSerializableDerived(1)]
    public class GameCurrencyCost : CurrencyCost
    {
        [MetaMember(2, 0)]
        public Currencies Type { get; set; }
    }
}

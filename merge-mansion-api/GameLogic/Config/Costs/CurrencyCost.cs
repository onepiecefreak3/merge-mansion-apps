using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Config.Costs
{
    [MetaSerializable]
    public abstract class CurrencyCost : ICost
    {
        [MetaMember(1, 0)]
        public long CurrencyAmount { get; set; }
    }
}

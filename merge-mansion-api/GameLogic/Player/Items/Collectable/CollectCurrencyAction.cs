using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(1)]
    public class CollectCurrencyAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public ICalculateCollectValue ValueCalculator { get; set; }
    }
}

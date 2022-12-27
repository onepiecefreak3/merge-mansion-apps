using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(2)]
    public class MergeMathBasedCollectValue : ICalculateCollectValue
    {
        [MetaMember(1, 0)]
        public Currencies Currency { get; set; }
        [MetaMember(2, 0)]
        public int Multiplier { get; set; }
    }
}

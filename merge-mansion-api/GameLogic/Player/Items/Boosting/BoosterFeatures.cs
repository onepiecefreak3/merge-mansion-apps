using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Boosting
{
    public sealed class BoosterFeatures
    {
        [MetaMember(1, 0)]
        public bool DoesBoost { get; set; }
        [MetaMember(2, 0)]
        public BoostAreaStyle BoostAreaStyle { get; set; }
        [MetaMember(3, 0)]
        public List<ItemType> AffectedItemsSet { get; set; }
        [MetaMember(4, 0)]
        public F32 BoostFactor { get; set; }
	}
}

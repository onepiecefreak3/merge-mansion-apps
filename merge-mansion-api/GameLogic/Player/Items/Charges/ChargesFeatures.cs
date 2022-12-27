using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Charges
{
    public class ChargesFeatures
    {
        [MetaMember(1, 0)]
        public bool SupportsCharges { get; set; }
        [MetaMember(2, 0)]
        public int DefaultInitialCharges { get; set; }
        [MetaMember(3, 0)]
        public ChargeMergeBehavior MergeBehavior { get; set; }
	}
}

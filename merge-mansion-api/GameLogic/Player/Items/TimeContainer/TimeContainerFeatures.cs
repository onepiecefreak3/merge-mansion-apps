using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.TimeContainer
{
    public class TimeContainerFeatures
    {
        [MetaMember(1, 0)]
        public bool StoresTime { get; set; }
        [MetaMember(2, 0)]
        public MetaDuration DefaultInitialTime { get; set; }
        [MetaMember(3, 0)]
        public TimeContainerMergeBehavior MergeBehavior { get; set; }
	}
}

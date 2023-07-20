using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Decay
{
    [MetaSerializable]
    public sealed class DecayState
    {
        [MetaMember(3, 0)]
        private MetaDuration relativeTimeSpendOnDecay { get; set; } // 0x20
        [MetaMember(4, 0)]
        private MetaTime lastTimeAddTime { get; set; } // 0x28

        [MetaMember(1, 0)]
        public MetaTime EstimatedTime { get; set; }
        [MetaMember(2, 0)]
        public MetaTime StartTime { get; set; }
    }
}

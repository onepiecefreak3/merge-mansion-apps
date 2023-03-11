using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Sink
{
    public class SinkFeatures
    {
        [MetaMember(1, 0)]
        public bool IsSink { get; set; }
        [MetaMember(2, 0)]
        public ISinkStateFactory Factory { get; set; }
        [MetaMember(3, 0)]
        public string OverrideSfx { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializable]
    public sealed class CollectableFeatures
    {
        [MetaMember(1)]
        public bool Collectable { get; set; }
        [MetaMember(2)]
        public ICollectAction CollectAction { get; set; }
        [MetaMember(3)]
        public string OverrideSfx { get; set; }
        [MetaMember(4)]
        public bool ConfirmCollectBelowMergeChainLevel { get; set; }
    }
}

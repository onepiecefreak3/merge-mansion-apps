using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    public sealed class CollectableFeatures
    {
        [MetaMember(1)]
        public bool Collectable { get; set; }
        [MetaMember(2)]
        public ICollectAction CollectAction { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(5)]
    [MetaSerializable]
    public class InfiniteEnergyCollectAction : ICollectAction
    {
        [MetaMember(1)]
        public MetaDuration Duration { get; set; }
    }
}

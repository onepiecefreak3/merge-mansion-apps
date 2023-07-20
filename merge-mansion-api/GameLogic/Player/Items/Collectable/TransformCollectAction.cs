using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(3)]
    [MetaSerializable]
    public class TransformCollectAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> TransformsInto { get; set; }
    }
}

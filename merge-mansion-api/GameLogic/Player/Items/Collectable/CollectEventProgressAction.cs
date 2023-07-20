using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(4)]
    [MetaSerializable]
    public class CollectEventProgressAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public int ProgressGiven { get; set; }
    }
}

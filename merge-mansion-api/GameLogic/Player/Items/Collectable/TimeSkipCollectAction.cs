using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class TimeSkipCollectAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public MetaDuration DurationToSkip { get; set; }
    }
}

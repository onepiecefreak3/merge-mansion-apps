using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.Metaplay.Core.Activables
{
    [MetaSerializable]
    public abstract class MetaActivablePrecursorCondition<TId> : PlayerCondition
    {
        [MetaMember(1, 0)]
        public TId Id { get; set; }
        [MetaMember(2, 0)]
        public bool Consumed { get; set; }
        [MetaMember(3, 0)]
        public MetaDuration Delay { get; set; }
    }
}

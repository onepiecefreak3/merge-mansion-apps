using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Activables
{
    public abstract class MetaActivableCooldownSpec
    {
        [MetaSerializableDerived(1)]
        public class Fixed: MetaActivableCooldownSpec
        {
            [MetaMember(1, 0)]
            public MetaDuration Duration { get; set; }
        }

        [MetaSerializableDerived(2)]
        public class ScheduleBased : MetaActivableCooldownSpec
        {
        }
    }
}

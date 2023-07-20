using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Activables
{
    public abstract class MetaActivableLifetimeSpec
    {
        [MetaSerializableDerived(1)]
        [MetaSerializable]
        public class Fixed : MetaActivableLifetimeSpec
        {
            [MetaMember(1)]
            public MetaDuration Duration { get; set; }
        }

        [MetaSerializableDerived(2)]
        public class ScheduleBased : MetaActivableLifetimeSpec
        {
        }

        [MetaSerializableDerived(3)]
        public class Forever : MetaActivableLifetimeSpec
        {
        }
    }
}

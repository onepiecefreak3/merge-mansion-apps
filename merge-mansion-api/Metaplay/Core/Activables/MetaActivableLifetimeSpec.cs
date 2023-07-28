using Metaplay.Core.Model;

namespace Metaplay.Core.Activables
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

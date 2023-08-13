using Metaplay.Core.Model;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    public abstract class MetaActivableLifetimeSpec
    {
        [MetaSerializableDerived(1)]
        public class Fixed : MetaActivableLifetimeSpec
        {
            [MetaMember(1)]
            public MetaDuration Duration { get; set; }

            public Fixed()
            {
            }

            public Fixed(MetaDuration duration)
            {
            }
        }

        [MetaSerializableDerived(2)]
        public class ScheduleBased : MetaActivableLifetimeSpec
        {
            public static MetaActivableLifetimeSpec.ScheduleBased Instance;
            public ScheduleBased()
            {
            }
        }

        [MetaSerializableDerived(3)]
        public class Forever : MetaActivableLifetimeSpec
        {
            public static MetaActivableLifetimeSpec.Forever Instance;
            public Forever()
            {
            }
        }

        protected MetaActivableLifetimeSpec()
        {
        }
    }
}
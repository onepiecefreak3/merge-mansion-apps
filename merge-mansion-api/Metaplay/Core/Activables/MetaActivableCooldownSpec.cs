using Metaplay.Core.Model;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    public abstract class MetaActivableCooldownSpec
    {
        [MetaSerializableDerived(1)]
        public class Fixed : MetaActivableCooldownSpec
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaDuration Duration { get; set; }

            public static MetaActivableCooldownSpec.Fixed Zero;
            public Fixed()
            {
            }

            public Fixed(MetaDuration duration)
            {
            }
        }

        [MetaSerializableDerived(2)]
        public class ScheduleBased : MetaActivableCooldownSpec
        {
            public static MetaActivableCooldownSpec.ScheduleBased Instance;
            public ScheduleBased()
            {
            }
        }

        protected MetaActivableCooldownSpec()
        {
        }
    }
}
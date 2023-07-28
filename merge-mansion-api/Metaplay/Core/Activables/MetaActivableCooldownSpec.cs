using Metaplay.Core.Model;

namespace Metaplay.Core.Activables
{
    public abstract class MetaActivableCooldownSpec
    {
        [MetaSerializableDerived(1)]
        [MetaSerializable]
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

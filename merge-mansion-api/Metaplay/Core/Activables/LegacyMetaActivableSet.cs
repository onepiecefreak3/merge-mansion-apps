using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class LegacyMetaActivableSet<TId, TActivableState>
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public Dictionary<TId, TActivableState> ActivableStates { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public Dictionary<TId, TActivableState> ErroneousActivableStates { get; set; }

        protected LegacyMetaActivableSet()
        {
        }
    }
}
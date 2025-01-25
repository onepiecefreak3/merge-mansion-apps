using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class MetaActivableSet<TId, TInfo, TActivableState> : IMetaActivableSet<TId, TInfo, TActivableState>, IMetaActivableSet<TId>, IMetaActivableSet
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        Dictionary<TId, TActivableState> _activableStates;
        [MetaMember(101, (MetaMemberFlags)0)]
        Dictionary<TId, TActivableState> _erroneousActivableStates;
        protected MetaActivableSet()
        {
        }
    }
}
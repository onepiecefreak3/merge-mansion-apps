using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class MetaActivableStateStorage
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public int NumActivated { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public int TotalNumConsumed { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public int NumFinalized { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public MetaActivableState.Activation? LatestActivation { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public MetaActivableState.DebugState Debug { get; set; }

        protected MetaActivableStateStorage()
        {
        }
    }
}
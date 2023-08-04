using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.Activables
{
    [MetaReservedMembers(200, 300)]
    [MetaSerializable]
    public abstract class ExtendableEventState<TId, TInfo> : MetaActivableState<TId, TInfo>
    {
        [MetaMember(200, (MetaMemberFlags)0)]
        public MetaTime? LastExtensionStartedAt;
        [MetaMember(201, (MetaMemberFlags)0)]
        public int LatestActivationNumExtended;
        [MetaMember(202, (MetaMemberFlags)0)]
        public int NumSoftFinalizedInLatestActivation;
        [IgnoreDataMember]
        public abstract ExtendableEventParams ExtendableEventParams { get; }

        protected ExtendableEventState()
        {
        }

        protected ExtendableEventState(TInfo info)
        {
        }
    }
}
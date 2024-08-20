using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace Metaplay.Core.LiveOpsEvent
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class LiveOpsEventContent : IMetaIntegration<LiveOpsEventContent>, IMetaIntegration
    {
        protected LiveOpsEventContent()
        {
        }

        [IgnoreDataMember]
        public virtual bool AudienceMembershipIsSticky { get; }
    }
}
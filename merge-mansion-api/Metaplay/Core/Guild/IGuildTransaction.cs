using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace Metaplay.Core.Guild
{
    [MetaSerializable((MetaSerializableFlags)1)]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public interface IGuildTransaction
    {
        [IgnoreDataMember]
        EntityId InvokingPlayerId { get; set; }

        [IgnoreDataMember]
        GuildTransactionConsistencyMode ConsistencyMode { get; }
    }
}
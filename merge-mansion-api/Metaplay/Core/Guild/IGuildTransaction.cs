using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace Metaplay.Core.Guild
{
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable((MetaSerializableFlags)1)]
    public interface IGuildTransaction
    {
        [IgnoreDataMember]
        EntityId InvokingPlayerId { get; set; }

        [IgnoreDataMember]
        GuildTransactionConsistencyMode ConsistencyMode { get; }
    }
}
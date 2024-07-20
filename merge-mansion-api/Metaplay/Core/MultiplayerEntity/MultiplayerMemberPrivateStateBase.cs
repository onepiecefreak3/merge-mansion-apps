using Metaplay.Core.Model;

namespace Metaplay.Core.MultiplayerEntity
{
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    public abstract class MultiplayerMemberPrivateStateBase
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public EntityId MemberId { get; set; } // 0x10

        protected MultiplayerMemberPrivateStateBase()
        {
        }

        protected MultiplayerMemberPrivateStateBase(EntityId memberId)
        {
        }
    }
}
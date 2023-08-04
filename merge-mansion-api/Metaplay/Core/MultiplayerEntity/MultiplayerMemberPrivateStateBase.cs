using Metaplay.Core.Model;

namespace Metaplay.Core.MultiplayerEntity
{
    [MetaSerializable]
    public abstract class MultiplayerMemberPrivateStateBase
    {
        [MetaMember(100, 0)]
        public EntityId MemberId { get; set; } // 0x10

        protected MultiplayerMemberPrivateStateBase()
        {
        }

        protected MultiplayerMemberPrivateStateBase(EntityId memberId)
        {
        }
    }
}
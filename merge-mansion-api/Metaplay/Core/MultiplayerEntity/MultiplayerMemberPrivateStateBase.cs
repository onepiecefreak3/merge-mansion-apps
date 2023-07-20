using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.MultiplayerEntity
{
    [MetaSerializable]
    public abstract class MultiplayerMemberPrivateStateBase
    {
        [MetaMember(100, 0)]
        public EntityId MemberId { get; set; } // 0x10
    }
}

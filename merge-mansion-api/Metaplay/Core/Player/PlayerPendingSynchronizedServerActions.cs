using Metaplay.Core.Model;
using Metaplay.Core.Serialization;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerPendingSynchronizedServerActions
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaSerialized<PlayerActionBase>[] PendingActions;
        public PlayerPendingSynchronizedServerActions()
        {
        }
    }
}
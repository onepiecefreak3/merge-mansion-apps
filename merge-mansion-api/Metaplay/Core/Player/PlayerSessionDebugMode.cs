using Metaplay.Core.Model;
using Metaplay.Core.Client;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    [MetaReservedMembers(100, 150)]
    public abstract class PlayerSessionDebugMode
    {
        public abstract EntityDebugConfig DebugConfigForCurrentSession { get; }

        protected PlayerSessionDebugMode()
        {
        }

        [MetaMember(100, (MetaMemberFlags)0)]
        PlayerSessionDebugModeParameters parameters;
        public PlayerDebugIncidentUploadMode IncidentUploadMode { get; }

        public PlayerSessionDebugMode(PlayerSessionDebugModeParameters parameters)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Client;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public abstract class PlayerSessionDebugMode
    {
        public abstract EntityDebugConfig DebugConfigForCurrentSession { get; }

        protected PlayerSessionDebugMode()
        {
        }
    }
}
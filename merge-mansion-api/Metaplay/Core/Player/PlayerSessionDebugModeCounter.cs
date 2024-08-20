using Metaplay.Core.Model;
using System;
using Metaplay.Core.Client;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(1)]
    public class PlayerSessionDebugModeCounter : PlayerSessionDebugMode
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int forNextNumSessions;
        public override EntityDebugConfig DebugConfigForCurrentSession { get; }

        public PlayerSessionDebugModeCounter(int forNextNumSessions)
        {
        }
    }
}
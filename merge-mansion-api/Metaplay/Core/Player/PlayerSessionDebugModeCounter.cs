using Metaplay.Core.Model;
using Metaplay.Core.Client;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(1)]
    public class PlayerSessionDebugModeCounter : PlayerSessionDebugMode
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int forNextNumSessions;
        public PlayerSessionDebugModeCounter(int forNextNumSessions)
        {
        }

        public PlayerSessionDebugModeCounter(PlayerSessionDebugModeParameters parameters, int forNextNumSessions)
        {
        }

        public override EntityDebugConfig DebugConfigForCurrentSession { get; }
    }
}
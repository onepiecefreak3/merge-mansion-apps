using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(14)]
    public class PlayerInitialClientVersionRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Min; // 0x10
        [MetaMember(2, (MetaMemberFlags)0)]
        public string Max; // 0x18
        public PlayerInitialClientVersionRequirement()
        {
        }

        public PlayerInitialClientVersionRequirement(string min, string max)
        {
        }
    }
}
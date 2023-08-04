using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializable]
    public struct PlayerNameHistoryEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string PlayerName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime ChangedAt { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool BySupport { get; set; }
    }
}
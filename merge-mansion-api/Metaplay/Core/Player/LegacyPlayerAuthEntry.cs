using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class LegacyPlayerAuthEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime AttachedAt { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public string ScidBindingId { get; set; }

        private LegacyPlayerAuthEntry()
        {
        }
    }
}
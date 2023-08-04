using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using Metaplay.Core;

namespace GameLogic.Player
{
    [MetaSerializableDerived(1)]
    public class PlayerSCIDAuthEntry : PlayerAuthEntryBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string SupercellIBindingId { get; set; }

        private PlayerSCIDAuthEntry()
        {
        }

        public PlayerSCIDAuthEntry(MetaTime attachedAt, string bindingId)
        {
        }
    }
}
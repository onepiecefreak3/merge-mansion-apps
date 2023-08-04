using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializable]
    public class SupercellIdBindingState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ServerOnly]
        public string PendingSupercellIdBindingEmail { get; set; }

        [ServerOnly]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string PendingSupercellIdBindingGameAccountId { get; set; }

        public SupercellIdBindingState()
        {
        }
    }
}
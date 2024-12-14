using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializable]
    public class SupercellIdBindingState
    {
        [ServerOnly]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string PendingSupercellIdBindingEmail { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ServerOnly]
        public string PendingSupercellIdBindingGameAccountId { get; set; }

        public SupercellIdBindingState()
        {
        }
    }
}
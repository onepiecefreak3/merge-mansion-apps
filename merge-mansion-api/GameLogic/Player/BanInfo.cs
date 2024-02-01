using Metaplay.Core.Model;
using Metaplay.Core;
using System;

namespace GameLogic.Player
{
    [MetaSerializable]
    public class BanInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime? ExpirationTime { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Reason { get; set; }

        public BanInfo()
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    [MetaReservedMembers(6, 100)]
    [MetaReservedMembers(1, 5)]
    public abstract class PlayerStatisticsBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime CreatedAt { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string InitialClientVersion { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime LastLoginAt { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int TotalLogins { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int TotalDesyncs { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public MetaTime LastImportAt { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string LastClientVersion { get; set; }

        protected PlayerStatisticsBase()
        {
        }
    }
}
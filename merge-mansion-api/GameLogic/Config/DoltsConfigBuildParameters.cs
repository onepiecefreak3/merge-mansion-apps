using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class DoltsConfigBuildParameters
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Branch { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string CommitHash { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Database { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Host { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int Port { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string UserName { get; set; }

        [Sensitive]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string Password { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool UseTag { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string Tag { get; set; }

        public DoltsConfigBuildParameters()
        {
        }
    }
}
using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 5, 6, 7, 8, 9 })]
    public class DoltsConfigBuildParameters
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public string CommitHash { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Database { get; set; }

        public DoltsConfigBuildParameters()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string BranchOrTag { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Environment { get; set; }
    }
}
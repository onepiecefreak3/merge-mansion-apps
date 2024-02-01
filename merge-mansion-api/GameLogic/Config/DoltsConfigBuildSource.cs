using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class DoltsConfigBuildSource : GameConfigBuildSource
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string BranchOrTag { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string CommitHash { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Database { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Environment { get; set; }
        public override string DisplayName { get; }

        public DoltsConfigBuildSource()
        {
        }
    }
}
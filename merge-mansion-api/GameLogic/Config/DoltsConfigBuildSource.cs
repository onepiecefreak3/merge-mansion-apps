using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Config
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(1)]
    public class DoltsConfigBuildSource : GameConfigBuildSource
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public string Database { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string Environment { get; set; }
        public override string DisplayName { get; }

        public DoltsConfigBuildSource()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string Branch { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Hash { get; set; }
    }
}
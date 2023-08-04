using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    public class MergeMansionGameConfigBuildParameters : GameConfigBuildParameters
    {
        public bool IsDolts;
        public override bool IsIncremental { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string SpreadSheetTitle { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string SpreadSheetUrl { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DoltsBranch { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string DoltsCommitHash { get; set; }

        public MergeMansionGameConfigBuildParameters()
        {
        }
    }
}
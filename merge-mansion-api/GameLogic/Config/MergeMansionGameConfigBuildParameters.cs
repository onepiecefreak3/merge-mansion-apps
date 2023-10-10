using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 3, 4 })]
    public class MergeMansionGameConfigBuildParameters : GameConfigBuildParameters
    {
        public override bool IsIncremental { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public string SpreadSheetTitle { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string SpreadSheetUrl { get; set; }

        public MergeMansionGameConfigBuildParameters()
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsDolts { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public DoltsConfigBuildParameters DoltsParameters { get; set; }
    }
}
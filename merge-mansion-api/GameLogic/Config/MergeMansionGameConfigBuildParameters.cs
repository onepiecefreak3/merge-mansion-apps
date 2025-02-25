using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Config
{
    [MetaBlockedMembers(new int[] { 3, 4, 5, 6, 100 })]
    [MetaSerializableDerived(1)]
    public class MergeMansionGameConfigBuildParameters : GameConfigBuildParameters
    {
        public override bool IsIncremental { get; }

        public MergeMansionGameConfigBuildParameters()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        [Obsolete]
        public string LegacySpreadSheetTitle { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Obsolete]
        [MetaFormNotEditable]
        public string LegacySpreadSheetUrl { get; set; }
    }
}
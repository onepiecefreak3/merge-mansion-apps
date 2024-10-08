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

        [Obsolete]
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public string LegacySpreadSheetTitle { get; set; }

        [Obsolete]
        [MetaFormNotEditable]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string LegacySpreadSheetUrl { get; set; }
    }
}
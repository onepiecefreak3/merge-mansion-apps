using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core.Forms;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1)]
    [MetaBlockedMembers(new int[] { 3, 4, 5, 6, 100 })]
    public class MergeMansionGameConfigBuildParameters : GameConfigBuildParameters
    {
        public override bool IsIncremental { get; }

        public MergeMansionGameConfigBuildParameters()
        {
        }

        [MetaFormNotEditable]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Obsolete]
        public string LegacySpreadSheetTitle { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        [Obsolete]
        public string LegacySpreadSheetUrl { get; set; }
    }
}
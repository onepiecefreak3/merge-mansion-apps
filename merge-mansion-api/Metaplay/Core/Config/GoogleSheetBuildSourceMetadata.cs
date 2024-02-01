using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(101)]
    public class GoogleSheetBuildSourceMetadata : GameConfigBuildSourceMetadata
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string SpreadsheetTitle { get; set; }

        public GoogleSheetBuildSourceMetadata()
        {
        }
    }
}
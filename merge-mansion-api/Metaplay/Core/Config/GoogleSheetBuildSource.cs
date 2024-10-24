using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(101)]
    public class GoogleSheetBuildSource : GameConfigBuildSource
    {
        [MetaFormDisplayProps("Google Spreadsheet Name", DisplayHint = "Name of the Google Spreadsheet to use as a data source.", DisplayPlaceholder = "Enter Google Spreadsheet Name")]
        [MetaValidateRequired]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Name { get; set; }

        [MetaFormDisplayProps("Google Spreadsheet ID", DisplayHint = "ID of the Google Spreadsheet to use as a data source.", DisplayPlaceholder = "Enter Google Spreadsheet ID")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [MetaFormFieldCustomValidator(typeof(GoogleSheetsIdValidator))]
        public string SpreadsheetId { get; set; }
        public override string DisplayName { get; }

        private GoogleSheetBuildSource()
        {
        }

        public GoogleSheetBuildSource(string name, string spreadsheetId)
        {
        }
    }
}
using Metaplay.Core.Forms;
using System;
using System.Text.RegularExpressions;

namespace Metaplay.Core.Config
{
    internal class GoogleSheetsIdValidator : MetaFormValidator<string>
    {
        private static Regex validator;
        public GoogleSheetsIdValidator()
        {
        }
    }
}
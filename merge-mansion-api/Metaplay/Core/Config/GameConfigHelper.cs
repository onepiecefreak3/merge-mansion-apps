using Metaplay.Core.Message;
using System;

namespace Metaplay.Core.Config
{
    public abstract class GameConfigHelper
    {
        public static string VariantColumnName;
        public static string AliasColumnName;

        public delegate void SheetFilterDelegate(string languageName, string flag);
    }
}
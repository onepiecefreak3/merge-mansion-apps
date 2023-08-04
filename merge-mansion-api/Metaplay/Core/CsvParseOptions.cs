using System;

namespace Metaplay.Core
{
    public class CsvParseOptions
    {
        public static CsvParseOptions Default;
        public string IgnoreMemberPrefix;
        public UnknownMemberHandling UnknownMemberHandling;
        public ExtraCellHandling ExtraCellHandling;
        public CsvParseOptions()
        {
        }
    }
}
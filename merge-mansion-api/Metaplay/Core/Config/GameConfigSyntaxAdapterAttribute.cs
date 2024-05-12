using System;

namespace Metaplay.Core.Config
{
    [AttributeUsage((AttributeTargets)388, AllowMultiple = true)]
    public class GameConfigSyntaxAdapterAttribute : Attribute
    {
        public GameConfigSyntaxAdapterAttribute.ReplaceRule[] HeaderReplaces;
        public GameConfigSyntaxAdapterAttribute.ReplaceRule[] HeaderPrefixReplaces;
        public GameConfigSyntaxAdapterAttribute(string[] headerReplaces, string[] headerPrefixReplaces)
        {
        }

        public struct ReplaceRule
        {
            public string From;
            public string To;
        }

        public bool EnsureHasKeyValueSheetHeader;
        public GameConfigSyntaxAdapterAttribute(string[] headerReplaces, string[] headerPrefixReplaces, bool ensureHasKeyValueSheetHeader)
        {
        }
    }
}
using System;

namespace Metaplay.Core.Analytics
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = true)]
    public class AnalyticsEventKeywordsAttribute : Attribute
    {
        public string[] Keywords { get; set; }

        public AnalyticsEventKeywordsAttribute(string[] keywords)
        {
        }
    }
}
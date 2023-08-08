using System;

namespace Metaplay.Core.Analytics
{
    [AttributeUsage((AttributeTargets)396)]
    public class BigQueryAnalyticsFormatAttribute : Attribute
    {
        public BigQueryAnalyticsFormatMode Mode { get; set; }

        public BigQueryAnalyticsFormatAttribute(BigQueryAnalyticsFormatMode mode)
        {
        }
    }
}
using System;

namespace Metaplay.Core.Analytics
{
    [AttributeUsage((AttributeTargets)4)]
    public class AnalyticsEventCategoryAttribute : Attribute
    {
        public string CategoryName { get; set; }

        public AnalyticsEventCategoryAttribute(string categoryName)
        {
        }
    }
}
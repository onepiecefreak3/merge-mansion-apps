using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Analytics
{
    [AttributeUsage((AttributeTargets)4)]
    public class AnalyticsEventAttribute : Attribute, ISerializableTypeCodeProvider
    {
        public string DisplayName;
        public int SchemaVersion;
        public string DocString;
        public bool IncludeInEventLog;
        public bool SendToAnalytics;
        public bool CanTrigger;
        public int TypeCode { get; }

        public AnalyticsEventAttribute(int typeCode, string displayName, int schemaVersion, string docString, bool includeInEventLog, bool sendToAnalytics, bool canTrigger)
        {
        }
    }
}
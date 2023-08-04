using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)12, AllowMultiple = false)]
    public class SupportedSchemaVersionsAttribute : Attribute
    {
        public MetaVersionRange SupportedSchemaVersions;
        public SupportedSchemaVersionsAttribute(int oldestSupportedVersion, int currentVersion)
        {
        }
    }
}
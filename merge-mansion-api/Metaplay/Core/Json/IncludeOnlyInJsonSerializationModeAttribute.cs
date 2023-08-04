using System;

namespace Metaplay.Core.Json
{
    [AttributeUsage((AttributeTargets)384)]
    public class IncludeOnlyInJsonSerializationModeAttribute : Attribute
    {
        public JsonSerializationMode Mode;
        public IncludeOnlyInJsonSerializationModeAttribute(JsonSerializationMode mode)
        {
        }
    }
}
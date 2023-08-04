using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)384)]
    public class MetaOnMemberDeserializationFailureAttribute : Attribute
    {
        public string MethodName;
        public MetaOnMemberDeserializationFailureAttribute(string methodName)
        {
        }
    }
}
using System;

namespace Metaplay.Core.Config
{
    [AttributeUsage((AttributeTargets)12)]
    public class ParseAsDerivedTypeAttribute : Attribute
    {
        public Type Type;
        public ParseAsDerivedTypeAttribute(Type type)
        {
        }
    }
}
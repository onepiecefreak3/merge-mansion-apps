using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384)]
    public class MetaFormExcludeDerivedTypeAttribute : MetaFormFieldDecoratorBaseAttribute
    {
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }

        public MetaFormExcludeDerivedTypeAttribute(Type[] excludedType)
        {
        }

        public MetaFormExcludeDerivedTypeAttribute(string[] excludedType)
        {
        }
    }
}
using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384)]
    public class MetaFormNotEditableAttribute : MetaFormFieldDecoratorBaseAttribute
    {
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }

        public MetaFormNotEditableAttribute()
        {
        }
    }
}
using System;

namespace Metaplay.Core.Forms
{
    public abstract class MetaFormFieldTypeHintAttribute : MetaFormFieldDecoratorBaseAttribute
    {
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }
        public abstract string FieldType { get; }
        public abstract object FieldTypeProps { get; }

        protected MetaFormFieldTypeHintAttribute()
        {
        }
    }
}
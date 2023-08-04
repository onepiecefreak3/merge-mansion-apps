using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384, AllowMultiple = false)]
    public abstract class MetaFormFieldDecoratorBaseAttribute : Attribute, IMetaFormFieldDecorator
    {
        public bool IsMultiDecorator { get; }
        public abstract string FieldDecoratorKey { get; }
        public abstract object FieldDecoratorValue { get; }

        protected MetaFormFieldDecoratorBaseAttribute()
        {
        }
    }
}
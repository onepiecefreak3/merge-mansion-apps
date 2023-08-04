using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384, AllowMultiple = true)]
    public abstract class MetaFormFieldValidatorBaseAttribute : MetaFormFieldMultiDecoratorBaseAttribute, IMetaFormFieldValidatorAttribute
    {
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }
        public abstract string ValidationRuleName { get; }
        public abstract object ValidationRuleProps { get; }
        public abstract Type CustomValidatorType { get; }

        protected MetaFormFieldValidatorBaseAttribute()
        {
        }
    }
}
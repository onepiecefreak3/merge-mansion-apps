using System;

namespace Metaplay.Core.Forms
{
    public class MetaFormFieldCustomValidatorAttribute : MetaFormFieldValidatorBaseAttribute
    {
        private Type _validatorType;
        public override string ValidationRuleName { get; }
        public override object ValidationRuleProps { get; }
        public override Type CustomValidatorType { get; }

        public MetaFormFieldCustomValidatorAttribute(Type validatorType)
        {
        }
    }
}
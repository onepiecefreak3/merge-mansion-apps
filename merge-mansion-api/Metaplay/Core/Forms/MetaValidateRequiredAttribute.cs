using System;

namespace Metaplay.Core.Forms
{
    public class MetaValidateRequiredAttribute : MetaFormFieldValidatorBaseAttribute
    {
        private string ErrorMessage { get; }
        public override string ValidationRuleName { get; }
        public override object ValidationRuleProps { get; }
        public override Type CustomValidatorType { get; }

        public MetaValidateRequiredAttribute(string errorMessage)
        {
        }

        public MetaValidateRequiredAttribute()
        {
        }
    }
}
using Metaplay.Core.Forms;
using System;

namespace GameLogic.Player.Items
{
    public class ValidateItemDefinitionMetaRefAttribute : MetaFormFieldValidatorBaseAttribute
    {
        public override string ValidationRuleName { get; }
        public override object ValidationRuleProps { get; }
        public override Type CustomValidatorType { get; }

        public ValidateItemDefinitionMetaRefAttribute()
        {
        }
    }
}
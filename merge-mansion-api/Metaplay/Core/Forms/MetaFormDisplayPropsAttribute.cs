using System;

namespace Metaplay.Core.Forms
{
    public class MetaFormDisplayPropsAttribute : MetaFormFieldDecoratorBaseAttribute
    {
        public string DisplayName { get; }
        public string DisplayHint { get; set; }
        public string DisplayPlaceholder { get; set; }
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }

        public MetaFormDisplayPropsAttribute(string displayName)
        {
        }
    }
}
using System;

namespace Metaplay.Core.Forms
{
    public class MetaFormFieldContextAttribute : MetaFormFieldMultiDecoratorBaseAttribute
    {
        public string Key;
        public object Value;
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }

        public MetaFormFieldContextAttribute(string key, object value)
        {
        }
    }
}
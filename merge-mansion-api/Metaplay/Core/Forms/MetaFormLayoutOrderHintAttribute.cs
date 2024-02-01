using System;

namespace Metaplay.Core.Forms
{
    [AttributeUsage((AttributeTargets)384)]
    public class MetaFormLayoutOrderHintAttribute : MetaFormFieldDecoratorBaseAttribute
    {
        public int Order { get; }
        public override string FieldDecoratorKey { get; }
        public override object FieldDecoratorValue { get; }

        public MetaFormLayoutOrderHintAttribute(int order)
        {
        }
    }
}
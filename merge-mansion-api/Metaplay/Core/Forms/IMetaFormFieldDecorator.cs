using System;

namespace Metaplay.Core.Forms
{
    public interface IMetaFormFieldDecorator
    {
        bool IsMultiDecorator { get; }

        string FieldDecoratorKey { get; }

        object FieldDecoratorValue { get; }
    }
}
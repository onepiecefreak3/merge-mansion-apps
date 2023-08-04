using System;

namespace Metaplay.Core.Forms
{
    public interface IMetaFormFieldValidatorAttribute
    {
        Type CustomValidatorType { get; }
    }
}
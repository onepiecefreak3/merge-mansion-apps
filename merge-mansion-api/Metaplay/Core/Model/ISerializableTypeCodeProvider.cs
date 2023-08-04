using System;

namespace Metaplay.Core.Model
{
    public interface ISerializableTypeCodeProvider
    {
        int TypeCode { get; }
    }
}
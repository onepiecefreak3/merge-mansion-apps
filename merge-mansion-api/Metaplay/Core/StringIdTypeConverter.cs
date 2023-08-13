using System;

namespace Metaplay.Core
{
    public class StringIdTypeConverter : StringTypeConverterHelper<IStringId>
    {
        private Type _stringIdType;
        public StringIdTypeConverter(Type stringIdType)
        {
        }
    }
}
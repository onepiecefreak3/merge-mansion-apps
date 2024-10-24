using System;

namespace Metaplay.Core.Serialization
{
    public abstract class MetaDeserializationConverter
    {
        public abstract WireDataType AcceptedWireDataType { get; }
        public abstract Type SourceType { get; }
        public virtual MetaDeserializationConverter.SourceDeserializationKind SourceDeserialization { get; }
        public abstract Type TargetType { get; }

        protected MetaDeserializationConverter()
        {
        }

        public enum SourceDeserializationKind
        {
            Normal = 0,
            Members = 1
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;
using Metaplay.Core.Serialization;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    public class EntityEventDeserializationFailureInfo
    {
        private static int MaxEventPayloadBytesRetained;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int EventPayloadBytesLength { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public byte[] EventPayloadBytesTruncated { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ExceptionType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ExceptionMessage { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int? UnknownEventTypeCode { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int? UnexpectedWireDataTypeValue { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string UnexpectedWireDataTypeName { get; set; }

        [IgnoreDataMember]
        public string DescriptionForEvent { get; }

        private EntityEventDeserializationFailureInfo()
        {
        }

        public EntityEventDeserializationFailureInfo(MetaMemberDeserializationFailureParams failureParams)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string EventPayloadTypeName { get; set; }
    }
}
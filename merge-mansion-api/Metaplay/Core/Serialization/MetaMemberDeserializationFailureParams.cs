using System;

namespace Metaplay.Core.Serialization
{
    public struct MetaMemberDeserializationFailureParams
    {
        public byte[] MemberPayload;
        public Exception Exception;
        public MetaSerializerTypeRegistry TypeInfo;
    }
}
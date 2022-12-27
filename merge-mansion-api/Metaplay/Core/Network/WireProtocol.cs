using System;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.IO;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Network
{
    public static class WireProtocol
    {
        public const int CompressionThresholdBytes = 0x2800;
        public const int ProtocolHeaderSize = 8;
        public const int MinClientWireProtocolVersion = 3;
        public const int MaxClientWireProtocolVersion = 10;
        public const int WireProtocolVersion = 3;
        public const int PacketHeaderSize = 4;
        public const int MaxPacketWirePayloadSize = 0x100000;
        public const int MaxPacketUncompressedPayloadSize = 0x500000;

        public static ProtocolStatus ParseProtocolHeader(byte[] buffer, int offset, string expectedGameMagic)
        {
            if (buffer[offset] != expectedGameMagic[0] ||
                buffer[offset + 1] != expectedGameMagic[1] ||
                buffer[offset + 2] != expectedGameMagic[2] ||
                buffer[offset + 3] != expectedGameMagic[3])
                return ProtocolStatus.InvalidGameMagic;

            if (buffer[offset + 4] > MaxClientWireProtocolVersion)
                return ProtocolStatus.WireProtocolVersionMismatch;

            return (ProtocolStatus)buffer[offset + 5];
        }

        public static WirePacketHeader DecodePacketHeader(byte[] buffer, int offset, bool enforcePacketPayloadSizeLimit)
        {
            if (offset + PacketHeaderSize >= buffer.Length)
                throw new ArgumentException(nameof(offset));

            var payloadSize = (buffer[offset + 1] << 0x10) | (buffer[offset + 2] << 8) | buffer[offset + 3];
            if (payloadSize > MaxPacketWirePayloadSize && enforcePacketPayloadSizeLimit)
                throw new InvalidOperationException($"Too large encoded packet size: {payloadSize}");

            // DEBUG
            //Console.WriteLine($"Type: {buffer[offset] & 7}, Comp: {(buffer[offset] >> 3) & 3}, Size: {payloadSize}");

            return new WirePacketHeader((WirePacketType)(buffer[offset] & 7), (WirePacketCompression)((buffer[offset] >> 3) & 3), payloadSize);
        }

        public static void EncodePacketHeader(WirePacketHeader header, byte[] buffer)
        {
            if (buffer.Length < PacketHeaderSize)
                throw new InvalidOperationException($"Buffer cannot hold the header with length {PacketHeaderSize}.");

            buffer[0] = (byte)((int)header.Type | ((int)header.Compression << 3));
            buffer[1] = (byte)(header.PayloadSize >> 0x10);
            buffer[2] = (byte)(header.PayloadSize >> 0x8);
            buffer[3] = (byte)header.PayloadSize;
        }

        public static MetaMessage DecodeMessage(byte[] buffer, int payloadOffset, int payloadSize, IGameConfigDataResolver resolver)
        {
            using var reader = new IOReader(buffer, payloadOffset, payloadSize);

            MetaMessage message=null;
            try
            {
                message = MetaSerialization.DeserializeTagged<MetaMessage>(reader, MetaSerializationFlags.SendOverNetwork, resolver, null, null);
            }
            catch (Exception e)
            {
                ;
            }

            // DEBUG: Output message type
            Console.WriteLine($"Received: {message.GetType().Name}");

            return message;
        }
    }
}

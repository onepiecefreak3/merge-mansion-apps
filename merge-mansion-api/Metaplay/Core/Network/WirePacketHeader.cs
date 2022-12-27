namespace Metaplay.Metaplay.Core.Network
{
	public struct WirePacketHeader
    {
        public WirePacketType Type; // 0x0
        public WirePacketCompression Compression; // 0x4
        public int PayloadSize; // 0x8

        public WirePacketHeader(WirePacketType type, WirePacketCompression compression, int payloadSize)
        {
            Type = type;
            Compression = compression;
            PayloadSize = payloadSize;
        }
    }
}

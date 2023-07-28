namespace Metaplay.Core.Network
{
    public enum WirePacketType
    {
        None = 0,
        Message = 1,
        Ping = 2,
        PingResponse = 3,
        HealthCheck = 4
    }
}

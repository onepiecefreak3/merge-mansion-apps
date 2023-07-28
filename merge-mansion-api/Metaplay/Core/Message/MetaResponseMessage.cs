namespace Metaplay.Core.Message
{
    public abstract class MetaResponseMessage : MetaMessage
    {
        public int RequestId { get; set; } // 0x10
        public MetaResponse Payload { get; set; } // 0x18
    }
}

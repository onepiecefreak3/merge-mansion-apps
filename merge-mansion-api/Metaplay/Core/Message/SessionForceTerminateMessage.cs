namespace Metaplay.Core.Message
{
	[MetaMessage(105, MessageDirection.ServerToClient, false)]
    public class SessionForceTerminateMessage : MetaMessage // TypeDefIndex: 980
    {
        // Properties
        public SessionForceTerminateReason Reason { get; set; } // 0x10

        // RVA: 0x2656E2C Offset: 0x2656E2C VA: 0x2656E2C
        public SessionForceTerminateMessage() { }

        // RVA: 0x2656E34 Offset: 0x2656E34 VA: 0x2656E34
        public SessionForceTerminateMessage(SessionForceTerminateReason reason)
        {
            Reason = reason;
        }
    }
}

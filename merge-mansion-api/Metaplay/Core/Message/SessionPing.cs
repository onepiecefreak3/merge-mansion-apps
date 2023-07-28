namespace Metaplay.Core.Message
{
    [MetaMessage(40, MessageDirection.ClientToServer, false)]
    public class SessionPing : MetaMessage
    {
        public int Id; // 0x10

        private SessionPing() { }

        public SessionPing(int id)
        {
            Id = id;
        }
    }
}

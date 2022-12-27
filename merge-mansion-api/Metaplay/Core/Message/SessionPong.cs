namespace Metaplay.Metaplay.Core.Message
{
	[MetaMessage(41, MessageDirection.ServerToClient, false)]
    public class SessionPong : MetaMessage
    {
        public int Id; // 0x10

        private SessionPong() { }

        public SessionPong(int id)
        {
            Id = id;
        }
    }
}

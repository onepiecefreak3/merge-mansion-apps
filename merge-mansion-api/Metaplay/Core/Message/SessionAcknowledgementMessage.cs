using Metaplay.Metaplay.Core.Session;

namespace Metaplay.Metaplay.Core.Message
{
    [MetaMessage(30, MessageDirection.Bidirectional, false)]
    public class SessionAcknowledgementMessage : SessionControlMessage
    {
        public SessionAcknowledgement Acknowledgement { get; set; } // 0x10

        public SessionAcknowledgementMessage() { }

        public SessionAcknowledgementMessage(SessionAcknowledgement acknowledgement)
        {
            Acknowledgement = acknowledgement;
        }
    }
}
